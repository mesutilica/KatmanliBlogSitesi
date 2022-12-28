using System.ComponentModel.DataAnnotations;

namespace KatmanliBlogSitesi.Entites
{
    public class User : IEntity
    {
        public int Id { get; set; }
        [Display(Name = "İsim"), StringLength(50)]
        public string Name { get; set; }
        [Display(Name = "Soyisim"), StringLength(50)]
        public string SurName { get; set; }
        [Display(Name = "Email"), StringLength(50)]
        public string Email { get; set; }
        [Display(Name = "Şifre"), StringLength(50)]
        public string Password { get; set; }
        [Display(Name = "Eklenme Tarihi"), ScaffoldColumn(false)]
        public DateTime CreateDate { get; set; } = DateTime.Now;
        [Display(Name = "Durum")]
        public bool IsActive { get; set; } // kullanıcıyı aktif veya pasif etmek için
        [Display(Name = "Admin")]
        public bool IsAdmin { get; set; } // kullanıcının admin paneline erişim hakkı için
    }
}
