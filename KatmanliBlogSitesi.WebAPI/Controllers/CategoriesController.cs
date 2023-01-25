using KatmanliBlogSitesi.Entites;
using KatmanliBlogSitesi.Service.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace KatmanliBlogSitesi.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly IService<Category> _service;

        public CategoriesController(IService<Category> service)
        {
            _service = service;
        }
        // GET: api/<CategoriesController>
        [HttpGet]
        public IEnumerable<Category> Get()
        {
            return _service.GetAll();
        }

        // GET api/<CategoriesController>/5
        [HttpGet("{id}")]
        public Category Get(int id)
        {
            return _service.Find(id);
        }

        // POST api/<CategoriesController>
        [HttpPost]
        public async Task<Category> PostAsync([FromBody] Category category)
        {
            await _service.AddAsync(category);
            await _service.SaveChangesAsync();
            return category;
        }

        // PUT api/<CategoriesController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> PutAsync(int id, [FromBody] Category category)
        {
            _service.Update(category);
            await _service.SaveChangesAsync();
            return Ok(category);
        }

        // DELETE api/<CategoriesController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteAsync(int id)
        {
            var category = await _service.FindAsync(id);
            _service.Delete(category);
            await _service.SaveChangesAsync();
            return Ok(category);
        }
    }
}
