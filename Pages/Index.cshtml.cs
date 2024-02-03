using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using LaunchDarkly.Sdk;
using LaunchDarkly.Sdk.Server;

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

        LdClient client = LDClient.Client;

        var context = Context.Builder("018d6ae1-d3c8-704b-8b12-6a8ce650ef5e")
        .Kind("device")
        .Name("Linux")
        .Build();

        LDClient.Context = context;

        var flagValue = client.BoolVariation("test-flag", context, false);
        ViewData["flagval"] = flagValue;
    }
}
