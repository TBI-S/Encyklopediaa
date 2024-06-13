using System.ComponentModel.DataAnnotations;

namespace Encyklopediaa.Models.Objects
{
    public class Użytkownik
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }

        [Required]
        public string Surname { get; set; }

        [Required]
        public int PhoneNumber { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Login { get; set; }

        [Required]
        public string Password { get; set; }

        public virtual ICollection<Artykul>? Artykułs { get; set; }
    }
}
