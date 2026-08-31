using System.Net.Http.Headers;
using System.Text.Json;
using BeatBuddySongMatcher.Models;

namespace BeatBuddySongMatcher.Services;

public class SupabaseService
{
    private const string SupabaseUrl =
        "https://kybyxzjcwkhiahwdzftt.supabase.co/rest/v1/";

    private const string SupabaseKey =
        "sb_publishable_g8rDNkrnqYWbXOVFsidZNg_eDRoxyMb";

    private readonly HttpClient _httpClient;

    public SupabaseService()
    {
        _httpClient = new HttpClient();

        _httpClient.DefaultRequestHeaders.Add(
            "apikey",
            SupabaseKey);

        _httpClient.DefaultRequestHeaders.Authorization =
            new AuthenticationHeaderValue(
                "Bearer",
                SupabaseKey);
    }

    public async Task<List<Song>> SearchSongsAsync(string search)
    {
        if (string.IsNullOrWhiteSpace(search))
            return [];

        var encodedSearch = Uri.EscapeDataString($"%{search}%");

        var url =
            $"{SupabaseUrl}songs" +
            $"?select=id,artist,title,beat,bpm" +
            $"&or=(artist.ilike.{encodedSearch},title.ilike.{encodedSearch})" +
            $"&order=artist.asc,title.asc" +
            $"&limit=20";

        var response = await _httpClient.GetAsync(url);

        response.EnsureSuccessStatusCode();

        var json = await response.Content.ReadAsStringAsync();

        return JsonSerializer.Deserialize<List<Song>>(
            json,
            new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            }) ?? [];
    }
}