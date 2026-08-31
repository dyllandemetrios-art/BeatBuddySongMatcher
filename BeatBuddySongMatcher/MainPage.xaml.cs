using BeatBuddySongMatcher.Models;
using BeatBuddySongMatcher.Services;

namespace BeatBuddySongMatcher;

public partial class MainPage : ContentPage
{
    private readonly SupabaseService _supabaseService;
    private CancellationTokenSource? _searchCancellation;

    public MainPage(SupabaseService supabaseService)
    {
        InitializeComponent();

        _supabaseService = supabaseService;
    }

    private async void OnSearchTextChanged(object? sender, TextChangedEventArgs e)
    {
        var search = e.NewTextValue?.Trim() ?? string.Empty;

        _searchCancellation?.Cancel();
        _searchCancellation?.Dispose();
        _searchCancellation = new CancellationTokenSource();

        var cancellationToken = _searchCancellation.Token;

        if (search.Length < 2)
        {
            ResultsList.ItemsSource = null;
            return;
        }

        try
        {
            // Attend 300 ms après la dernière frappe.
            await Task.Delay(300, cancellationToken);

            if (cancellationToken.IsCancellationRequested)
                return;

            var songs = await _supabaseService.SearchSongsAsync(search);

            if (cancellationToken.IsCancellationRequested)
                return;

            ResultsList.ItemsSource = songs;

            if (songs.Count == 0)
            {
                NoResultsLabel.IsVisible = true;
            }
            else
            {
                NoResultsLabel.IsVisible = false;
            }
        }
        catch (OperationCanceledException)
        {
            // Recherche annulée parce que l'utilisateur continue de taper.
        }
        catch (HttpRequestException)
        {
            ResultsList.ItemsSource = null;
            NoResultsLabel.IsVisible = false;

            await DisplayAlertAsync(
                "Connexion impossible",
                "Impossible de contacter le serveur. Vérifie ta connexion Internet.",
                "OK");
        }
        catch (Exception)
        {
            ResultsList.ItemsSource = null;
            NoResultsLabel.IsVisible = false;

            await DisplayAlertAsync(
                "Erreur",
                "Une erreur est survenue pendant la recherche.",
                "OK");
        }
    }

    private async void OnSearchButtonPressed(object? sender, EventArgs e)
    {
        var search = SearchBar.Text?.Trim() ?? string.Empty;

        if (search.Length < 2)
            return;

        try
        {
            var songs = await _supabaseService.SearchSongsAsync(search);

            ResultsList.ItemsSource = songs;
            NoResultsLabel.IsVisible = songs.Count == 0;

            if (songs.Count == 0)
            {
                await DisplayAlertAsync(
                    "Aucun résultat",
                    $"Aucun morceau trouvé pour « {search} ».",
                    "OK");
            }
        }
        catch (HttpRequestException)
        {
            await DisplayAlertAsync(
                "Connexion impossible",
                "Impossible de contacter le serveur. Vérifie ta connexion Internet.",
                "OK");
        }
        catch (Exception)
        {
            await DisplayAlertAsync(
                "Erreur",
                "Une erreur est survenue pendant la recherche.",
                "OK");
        }
    }

    private void OnSongSelected(object? sender, SelectionChangedEventArgs e)
    {
        if (e.CurrentSelection.FirstOrDefault() is not Song song)
            return;

        SelectedSongLabel.Text = song.Title;
        ArtistLabel.Text = song.Artist;
        BeatLabel.Text = song.Beat;
        BpmLabel.Text = song.Bpm.ToString();

        ResultsList.SelectedItem = null;
    }
    
    private async void OnSingularSoundTapped(object? sender, TappedEventArgs e)
    {
        try
        {
            await Launcher.Default.OpenAsync(
                "https://www.singularsound.com/");
        }
        catch (Exception)
        {
            await DisplayAlertAsync(
                "Impossible d'ouvrir le site",
                "Le site de Singular Sound ne peut pas être ouvert.",
                "OK");
        }
    }
}