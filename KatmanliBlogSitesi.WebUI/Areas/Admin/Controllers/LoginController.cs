using KatmanliBlogSitesi.Entites;
using KatmanliBlogSitesi.Service.Abstract;
using KatmanliBlogSitesi.WebUI.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace KatmanliBlogSitesi.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class LoginController : Controller
    {
        private readonly IService<User> _userService;

        public LoginController(IService<User> service)
        {
            _userService = service;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> IndexAsync(LoginViewModel loginViewModel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var account = await _userService.FirstOrDefaultAsync(x => x.IsActive && x.Email == loginViewModel.Email && x.Password == loginViewModel.Password);
                    if(account == null)
                        ModelState.AddModelError("", "Giriş Başarısız!");
                    else
                    {
                        var claims = new List<Claim>()
                        {
                            new Claim(ClaimTypes.Name, account.Name),
                            new Claim("Role", account.IsAdmin ? "Admin" : "User") // eğer giriş yapan kullanıcı adminse ona admin rolünü ver değilse düz kullanıcı(user) rolünü ver
                        };
                        var userIdentity = new ClaimsIdentity(claims, "Login");
                        ClaimsPrincipal principal= new ClaimsPrincipal(userIdentity);
                        await HttpContext.SignInAsync(principal);
                        return Redirect("/Admin/");
                    }
                }
                catch (Exception)
                {
                    ModelState.AddModelError("", "Hata Oluştu!");
                }
            }
            return View(loginViewModel);
        }
    }
}
