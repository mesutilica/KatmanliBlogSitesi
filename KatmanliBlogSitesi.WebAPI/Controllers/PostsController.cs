using KatmanliBlogSitesi.Entites;
using KatmanliBlogSitesi.Service.Abstract;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;

namespace KatmanliBlogSitesi.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostsController : ControllerBase
    {
        private readonly IService<Post> _service;

        public PostsController(IService<Post> service)
        {
            _service = service;
        }

        // GET: api/<PostsController>
        [HttpGet]
        public async Task<IEnumerable<Post>> GetAsync()
        {
            return await _service.GetAllAsync();
        }

        // GET api/<PostsController>/5
        [HttpGet("{id}")]
        public async Task<Post> GetAsync(int id)
        {
            return await _service.FindAsync(id);
        }

        // POST api/<PostsController>
        [HttpPost]
        public async Task<ActionResult> PostAsync([FromBody] Post post)
        {
            await _service.AddAsync(post);
            await _service.SaveChangesAsync();
            return Ok(post);
        }

        // PUT api/<PostsController>/5
        [HttpPut]
        public async Task<ActionResult> Put([FromBody] Post post)
        {
            _service.Update(post);
            await _service.SaveChangesAsync();
            return Ok(post);
        }

        // DELETE api/<PostsController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteAsync(int id)
        {
            var post = await _service.FindAsync(id);
            _service.Delete(post);
            await _service.SaveChangesAsync();
            return Ok(post);
        }
    }
}
