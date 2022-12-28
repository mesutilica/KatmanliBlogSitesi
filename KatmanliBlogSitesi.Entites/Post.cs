using System.ComponentModel.DataAnnotations;

namespace KatmanliBlogSitesi.Entites
{
    public class Post : IEntity
    {
        public int Id { get; set; }
        [StringLength(50), Display(Name = "İçerik Adı")]
        public string Name { get; set; }
        [Display(Name = "İçerik Açıklaması")]
        public string? Description { get; set; }
        [Display(Name = "Eklenme Tarihi"), ScaffoldColumn(false)]
        public DateTime CreateDate { get; set; } = DateTime.Now;
        [StringLength(150), Display(Name = "İçerik Resmi")]
        public string? Image { get; set; }
        [Display(Name = "Kategori")]
        public int CategoryId { get; set; } // ForeignKey
        [Display(Name = "Kategori")]
        public virtual Category? Category { get; set; }
    }
}
