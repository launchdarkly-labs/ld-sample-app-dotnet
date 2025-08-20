using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using LaunchDarkly.Sdk;
using LaunchDarkly.Sdk.Server;
using LaunchDarkly.Sdk.Server.Subsystems;

namespace dotnetapp.Pages;

public class IndexModel : PageModel
{
    private readonly ILogger<IndexModel> _logger;

    public IndexModel(ILogger<IndexModel> logger)
    {
        _logger = logger;
    }

    public void OnGet()
    {
        var currentPath = Request.Path.Value;
        var currentRouteUrl = Url.RouteUrl(RouteData.Values);
        ViewData["CurrentPath"] = currentPath;
        ViewData["CurrentRouteUrl"] = currentRouteUrl;

        LdClient client = LDClient.Client;

        var userContext = Context.Builder("user-018e7bd4-ab96-782e-87b0-b1e32082b481")
            .Kind("user")
            .Name("Miriam Wilson")
            .Set("language", "en")
            .Set("tier", "premium")
            .Set("userId", "mwilson")
            .Set("role", "developer")
            .Set("email", "miriam.wilson@example.com")
            .Build();
        var devContext = Context.Builder("device-018e7bd4-ab96-782e-87b0-b1e32082b481")
            .Kind("device")
            .Set("os", "macOS")
            .Set("osVersion", "15.6")
            .Set("model", "MacBook Pro")
            .Set("manufacturer", "Apple")
            .Build();

        var context = Context.MultiBuilder()
            .Add(userContext)
            .Add(devContext)
            .Build();

        var flagHomeSlider = client.BoolVariation("release-home-page-slider", context, false);
        ViewData["flagHomeSlider"] = flagHomeSlider;
        var flagPromo1 = client.BoolVariation("coffee-promo-1", context, false);
        ViewData["flagPromo1"] = flagPromo1;
        var flagPromo2 = client.BoolVariation("coffee-promo-2", context, false);
        ViewData["flagPromo2"] = flagPromo2;
    }
}
