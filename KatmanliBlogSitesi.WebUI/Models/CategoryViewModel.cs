using KatmanliBlogSitesi.Entites;

namespace KatmanliBlogSitesi.WebUI.Models
{
    public class CategoryViewModel
    {
        public Category Category { get; set; }
        public List<Post>? Posts { get; set; }
    }
}
