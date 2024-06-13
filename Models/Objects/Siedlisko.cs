using System.ComponentModel.DataAnnotations;

namespace Encyklopediaa.Models.Objects
{
    public class Siedlisko
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string Location { get; set; }

        public ICollection<Gatunek> Gatuneks { get; set; } = new List<Gatunek>();
    }
}
