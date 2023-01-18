using KatmanliBlogSitesi.Entites;
using KatmanliBlogSitesi.Service.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace KatmanliBlogSitesi.WebUI.ViewComponents
{
    public class Categories : ViewComponent
    {
        private readonly IService<Category> _service;

        public Categories(IService<Category> postService)
        {
            _service = postService;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View(await _service.GetAllAsync());
        }
    }
}
