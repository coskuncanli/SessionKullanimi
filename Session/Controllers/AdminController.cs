using Microsoft.AspNetCore.Mvc;
using Session.Models;

namespace Session.Controllers
{
    public class AdminController : Controller
    {

        public IActionResult Index()
        {
            string? ses = HttpContext.Session.GetString("username");
            if(ses == null)
            {
                return RedirectToAction("Login", "Admin");
            }
            else
            {
                ViewBag.User = ses;
            }
            return View();
        }


        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(User user)
        {
            if (ModelState.IsValid)
            {
                User? x = UserInit.Init().FirstOrDefault(x=>x.Username==user.Username&&x.Password==user.Password);
                if (x == null)
                {
                    ViewBag.LoginError = "Hatalı kullanıcı adı ya da şifre";
                }
                else
                {
                    HttpContext.Session.SetString("username", user.Username);
                    return RedirectToAction("Index", "Admin");
                }
            }
            return View();
        }
    }
}
