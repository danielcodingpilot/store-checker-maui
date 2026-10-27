# StoreChecker.Maui

A .NET MAUI package that detects where the app was installed from.

This project is a .NET MAUI port of the original Expo/React Native module:
https://github.com/tttocklll/store_checker

## What it detects

- Play Store
- Play Package Installer
- Amazon App Store
- Huawei AppGallery
- Samsung Galaxy Store
- Samsung Smart Switch Mobile
- OPPO App Market
- Xiaomi GetApps
- Vivo App Store
- RuStore
- App Store
- TestFlight
- Local source / sideloaded build
- Other source
- Unknown

## Install

```bash
dotnet add package StoreChecker.Maui
```

## Usage

```csharp
using StoreChecker.Maui;

var source = await StoreChecker.GetSourceAsync();

switch (source)
{
    case StoreSource.PlayStore:
        // Play Store
        break;

    case StoreSource.AppStore:
        // App Store
        break;

    case StoreSource.TestFlight:
        // TestFlight
        break;

    case StoreSource.LocalSource:
        // Installed from local build or sideload
        break;
}
```

## How it works

- Android reads the installer package name reported by the OS and maps it to a known store.
- iOS checks the app receipt and embedded provisioning profile to distinguish App Store vs TestFlight vs local installs.
- Web/unsupported targets return `Unknown`.

## License

MIT
