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

        public async Task<IActionResult> IndexAsync()
        {
            return View(await _postService.GetAllAsync());
        }

        public async Task<IActionResult> Search(string ara)
        {
            return View(await _postService.GetAllAsync(p => p.Name.Contains(ara)));
        }

        public async Task<IActionResult> DetailAsync(int id)
        {
            Post post = await _postService.FindAsync(id);
            return View(post);
        }
    }
}
