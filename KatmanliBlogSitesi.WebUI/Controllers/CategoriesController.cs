using KatmanliBlogSitesi.Entites;
using KatmanliBlogSitesi.Service.Abstract;
using KatmanliBlogSitesi.WebUI.Models;
using Microsoft.AspNetCore.Mvc;

namespace KatmanliBlogSitesi.WebUI.Controllers
{
    public class CategoriesController : Controller
    {
        private readonly IService<Category> _service;
        private readonly IService<Post> _servicePost;

        public CategoriesController(IService<Category> service, IService<Post> servicePost)
        {
            _service = service;
            _servicePost = servicePost;
        }

        public async Task<IActionResult> IndexAsync(int id)
        {
            var model = new CategoryViewModel()
            {
                Category = await _service.FindAsync(id),
                Posts = await _servicePost.GetAllAsync(p => p.CategoryId == id)
            };

            return View(model);
        }
    }
}
