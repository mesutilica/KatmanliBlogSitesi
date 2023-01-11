using KatmanliBlogSitesi.Entites;
using KatmanliBlogSitesi.Service.Abstract;
using KatmanliBlogSitesi.WebUI.Models;
using Microsoft.AspNetCore.Mvc;

namespace KatmanliBlogSitesi.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class LoginController : Controller
    {
        private readonly IService<User> _service;

        public LoginController(IService<User> service)
        {
            _service = service;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(LoginViewModel loginViewModel)
        {
            return View();
        }
    }
}
