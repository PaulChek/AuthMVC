using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Security.Claims;

namespace AuthMVC.Controllers {
    public class HomeController : Controller {

        public IActionResult Index() {
            return View();
        }
        [Authorize]
        [Route("[action]")]
        public IActionResult Secret() {
            return View();
        }
        [Route("[action]")]
        public IActionResult Authenticate() {
            var claims = new List<Claim> {
               new Claim(ClaimTypes.Name, "Paul"),
               new Claim(ClaimTypes.Email, "Paul@check.com")
            };

            var identity = new ClaimsIdentity(claims, "Grandma Word");

            var userprincipal = new ClaimsPrincipal(new[] { identity });

            HttpContext.SignInAsync(userprincipal);

            return RedirectToAction("Index");
        }
    }
}
