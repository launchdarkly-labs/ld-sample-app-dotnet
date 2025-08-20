using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace dotnetapp.Pages
{
    public class ContactModel : PageModel
    {
        public void OnGet()
        {
            var currentPath = Request.Path.Value;
            var currentRouteUrl = Url.RouteUrl(RouteData.Values);
            ViewData["CurrentPath"] = currentPath;
            ViewData["CurrentRouteUrl"] = currentRouteUrl;
        }
    }
}
