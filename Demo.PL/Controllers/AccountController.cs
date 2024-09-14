using Demo.PL.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Demo.PL.Controllers
{
    public class AccountController : Controller
    {
        #region Register
        [HttpGet]
        public IActionResult Register()
        {
            return View(); 
        }

        //[HttpPost]
        //public IActionResult Register(RegisterViewModel registerView)
        //{
        //    return View();
        //}
        #endregion

        #region Login
        //public IActionResult Login()
        //      {
        //          return View();
        //      }
        #endregion
    }
}
