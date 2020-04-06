using Microsoft.AspNetCore.Mvc;

namespace MBAM.Annotations.Presentation.Controllers
{
    public class ErrorController : Controller
    {
        [Route("/Error")]
        [Route("/Error/{id}")]
        public IActionResult Error(string id)
        {
            switch (id)
            {
                case "404":
                    return View("NotFound");
            }

            return View("Error");
        }
    }
}
