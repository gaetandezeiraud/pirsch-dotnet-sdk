# Unofficial Pirsch .Net SDK

This is the unofficial .Net client SDK for Pirsch. For details, please check out the [documentation](https://docs.pirsch.io/).   
You are free to extend the SDK to be compatible with ASP.net. It's not the case for the moment.

Available on NuGet: https://www.nuget.org/packages/Pirsch.DotNet.SDK/

## Usage

See **DesktopConsole** and **UWPConsole** examples.

In this examples, I generate a random ip. But, if you want the Countries data. You can Ping your website to get the internet Ip Address of the user.

## How filter data?

Pirsch is design for web analytics. So, if you want to use this SDK in the case of a Terminal, WPF or UWP app. We need to use some tricks.

First of all. In order to be respectfull about user privacy, Pirsch don't save the architecture of the user system (provided by the User Agent) nor the Operating System version. If you want this data, this solution is not for you.

Here a sample of User Agents that you can use to filter data. Here I use Chrome, but it's not necessary.

### Windows - Desktop (Chrome)

* Browser: Chrome
* Operating System: Windows
* Platform: Desktop

```
Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/77.0.3865.90 Safari/537.36
```

### macOS - Desktop (Chrome)

* Browser: Chrome
* Operating System: macOS
* Platform: Desktop

```
Mozilla/5.0 (Macintosh; Intel Mac OS X 11_2_3) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/89.0.4389.90 Safari/537.36
```

### Linux - Desktop (Chrome)

* Browser: Chrome
* Operating System: Linux
* Platform: Desktop

```
Mozilla/5.0 (X11; Linux x86_64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/89.0.4389.90 Safari/537.36
```

### Android - Mobile (Chrome)

* Browser: Chrome
* Operating System: Android
* Platform: Mobile

```
Mozilla/5.0 (Linux; Android 10; SM-A205U) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/89.0.4389.105 Mobile Safari/537.36.
```

### iOS - Mobile

* Browser: Chrome
* Operating System: iOS
* Platform: Mobile

```
Mozilla/5.0 (iPhone; CPU iPhone OS 14_4 like Mac OS X) AppleWebKit/605.1.15 (KHTML, like Gecko) CriOS/87.0.4280.77 Mobile/15E148 Safari/604.1
```

## License

MIT