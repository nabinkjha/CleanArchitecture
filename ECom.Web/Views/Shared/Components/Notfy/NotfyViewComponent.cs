using Microsoft.AspNetCore.Mvc;

namespace ECom.Web.Views.Shared.Components.Title
{
    public class NotfyViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}