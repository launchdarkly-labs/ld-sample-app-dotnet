# LaunchDarkly Sample App for .NET (C#) and JavaScript

## Requirements

* [.NET 9](https://dotnet.microsoft.com/en-us/download/dotnet/9.0)
* LaunchDarkly Flags:
  - **Release: UI Enhancements**, key: `release-ui-enhancements`
  - **Release: Home Page Slider**, key: `release-home-page-slider`
  - **Coffee Promo 1**, key: `coffee-promo-1`
  - **Coffee Promo 2**, key: `coffee-promo-2`
  - **Banner Text**, key: `banner-text`

## Setup

To get started, clone this repo locally

```
git clone https://github.com/launchdarkly-labs/ld-sample-app-dotnet.git
cd ld-sample-app-dotnet
```

Build the application

```
dotnet build
```

Add LaunchDarkly keys

* Rename `.env.example` to `.env`
* In the `.env` file, replace the fake keys with your LaunchDarkly SDK key and client-side key

## Run

To run the site:

```
dotnet run
```

In your browser, navigate to:

```
http://localhost:3000
```

Enjoy!