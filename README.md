# 🥁 BeatBuddy Song Matcher

**BeatBuddy Song Matcher** is a small companion application designed to help **BeatBuddy** users quickly find a suitable drum beat for a song.

Instead of manually browsing through BeatBuddy styles and presets, the application lets the user search for a song by **artist and title** and retrieve useful information such as its **tempo (BPM)** and corresponding BeatBuddy beat information.

The project started as a personal tool to reproduce and modernize the workflow of existing BeatBuddy song-matching resources, with a cleaner and more convenient interface.

---

## 🎯 Project Goal

The idea is simple:

> **Search for a song → find its tempo → identify a suitable BeatBuddy drum beat.**

For example, a user can start typing an artist or song title, select a result from the suggestions, and obtain the information needed to configure their BeatBuddy pedal.

The application was designed primarily for musicians who want to spend less time searching through drum presets and more time playing.

---

## ✨ Features

- 🔎 Search songs by **artist and title**
- ⚡ Search suggestions / autocomplete
- 🥁 Display BeatBuddy-compatible beat information
- 🎵 Display song tempo in **BPM**
- 📚 Song database
- 📱 Mobile-oriented user interface
- 💾 Local data support using SQLite
- ☁️ Backend/database experimentation for remotely stored song data
- 🤖 Android emulator testing during development

---

## 🛠️ Technologies

The mobile application was developed using:

- **C#**
- **.NET MAUI**
- **XAML**
- **SQLite**
- **REST APIs**
- **Supabase** during backend/database experimentation
- **JetBrains Rider**
- **Android SDK**
- **OpenJDK 21**
- Android Emulator / Pixel 8 virtual device

The project was developed with **.NET 10** and the MAUI workload.

---

## 🏗️ Application Structure

The MAUI application follows the standard .NET MAUI structure.

Important parts of the project include:

### `MainPage.xaml`

Contains the main user interface, including the song search interface and the list used to display search suggestions/results.

### `MauiProgram`

Configures and initializes the MAUI application and its dependencies.

### `AppShell`

Defines the application's navigation structure.

### Local database

SQLite was used to experiment with storing and querying song information locally.

This allows the application to access its song catalogue without requiring every operation to depend on a remote service.

### Remote data

A remote backend using **Supabase / REST requests** was also explored as a way of maintaining and distributing the song database independently from the application itself.

---

## 🔍 Search Workflow

The intended user experience is deliberately simple:

**1.** Open the application.

**2.** Start typing:

`Artist - Song`

**3.** Autocomplete proposes matching songs.

**4.** Select the desired song.

**5.** The application displays the relevant information, including the song's BPM and BeatBuddy beat information.

This makes the application useful while rehearsing or preparing songs, where manually searching through a large list of BeatBuddy presets would otherwise interrupt the workflow.

---

## 💡 Why I Built It

I use music software and hardware as part of my own musical projects and wanted a faster way to find appropriate BeatBuddy drum patterns for existing songs.

The project was also an opportunity to work with technologies outside my usual game-development environment, particularly:

- .NET MAUI
- mobile development
- Android tooling
- SQLite
- REST APIs
- remote databases
- search/autocomplete interfaces

It therefore became both a practical musician's tool and a software-development learning project.

---

# 📱 Android Development

A native Android version was developed and successfully tested through the Android development environment.

During development, the project required setting up the complete MAUI/Android toolchain, including the Android SDK, JDK 21 and an Android virtual device.

A **Pixel 8 virtual device** was used to run and test the application.

The long-term objective was initially to distribute BeatBuddy Song Matcher **for free through Google Play**.

---

# 🌐 Moving Away From Google Play

The Android application ultimately did **not reach a public Google Play release**.

This was not caused by a technical limitation of the application itself.

Google Play requires newer personal developer accounts to complete a **closed testing phase before receiving production access**. This includes recruiting a minimum number of testers who must opt into the test and remain enrolled for a required period.

For a small, free, independent utility developed primarily as a personal/community project, organizing a mandatory external testing group added considerably more distribution overhead than the project justified.

Rather than recruiting testers solely to satisfy the publication process, I decided not to pursue the Google Play release.

The project remains preserved here as a functional development project and as a record of the work done on the mobile version.

Future development can instead focus on a **browser-based version**, which removes the installation and store-distribution barrier entirely:

> Open the website → search for a song → get the BeatBuddy information.

No Play Store.  
No installation.  
No mandatory closed-testing program.

---

## 🚧 Project Status

**Android / .NET MAUI version:** Development completed to prototype/application stage  
**Google Play release:** Abandoned before public release  
**Reason:** Google Play closed-testing / production-access requirements  
**Future direction:** Web-based BeatBuddy Song Matcher

---

## 🎸 About

BeatBuddy Song Matcher is an independent project created as a practical companion tool for musicians using the BeatBuddy drum pedal.

It is not an official BeatBuddy product and is not affiliated with the manufacturer of BeatBuddy.

---

## 📄 License

License information can be added depending on the future distribution model of the project.
