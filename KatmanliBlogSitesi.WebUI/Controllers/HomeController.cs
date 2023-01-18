using KatmanliBlogSitesi.Entites;
using KatmanliBlogSitesi.Service.Abstract;
using KatmanliBlogSitesi.WebUI.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace KatmanliBlogSitesi.WebUI.Controllers
{
    public class HomeController : Controller
    {
        private readonly IService<Post> _postService;

        public HomeController(IService<Post> service)
        {
            _postService = service;
        }

        public async Task<IActionResult> IndexAsync()
        {
            List<Post> model = await _postService.GetAllAsync();
            return View(model);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}