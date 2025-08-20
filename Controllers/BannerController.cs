using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using LaunchDarkly.Sdk;
using LaunchDarkly.Sdk.Server;

[Route("api/[controller]")]
[ApiController]
[Produces("application/json")]
public class BannerController : ControllerBase
{
    private readonly LdClient ldclient;
    private readonly Context ldcontext;

    public BannerController()
    {
        ldclient = LDClient.Client;

        Context userContext = Context.Builder("user-018e7bd4-ab96-782e-87b0-b1e32082b481")
            .Kind("user")
            .Name("Miriam Wilson")
            .Set("language", "en")
            .Set("tier", "premium")
            .Set("userId", "mwilson")
            .Set("role", "developer")
            .Set("email", "miriam.wilson@example.com")
            .Build();
        Context devContext = Context.Builder("device-018e7bd4-ab96-782e-87b0-b1e32082b481")
            .Kind("device")
            .Set("os", "macOS")
            .Set("osVersion", "15.6")
            .Set("model", "MacBook Pro")
            .Set("manufacturer", "Apple")
            .Build();
        ldcontext = Context.MultiBuilder()
            .Add(userContext)
            .Add(devContext)
            .Build();
    }

    [HttpGet]
    public ActionResult<IEnumerable<string>> Get()
    {
        var primaryBanner = ldclient.StringVariation("banner-text", ldcontext, "No banner text found!");

        return Ok(new { primaryBanner });
    }
}

