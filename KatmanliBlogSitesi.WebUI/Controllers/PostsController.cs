using KatmanliBlogSitesi.Entites;
using KatmanliBlogSitesi.Service.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace KatmanliBlogSitesi.WebUI.Controllers
{
    public class PostsController : Controller
    {
        private readonly IService<Post> _postService;

        public PostsController(IService<Post> postService)
        {
            _postService = postService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> DetailAsync(int id)
        {
            Post post = await _postService.FindAsync(id);
            return View(post);
        }
    }
}
