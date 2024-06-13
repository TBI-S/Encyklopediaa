using System.ComponentModel.DataAnnotations;

namespace Encyklopediaa.Models.Objects
{
    public class Gatunek
    {
        [Key]
        public int Id { get; set; }


        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string SecurityStatus { get; set; }

        [Required]
        public int RodzinaId { get; set; }
        public virtual Rodzina Rodzina { get; set; }

        public ICollection<Siedlisko> Siedliskos { get; set; } = new List<Siedlisko>();
    }
}
