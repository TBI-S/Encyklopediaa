using System.ComponentModel.DataAnnotations;

namespace Encyklopediaa.Models.Objects
{
    public class Rodzina
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }

        public virtual ICollection<Gatunek>? Gatuneks { get; set; }
        public virtual ICollection<Artykul>? Artykułs { get; set; }
    }
}
