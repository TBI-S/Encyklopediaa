using System.ComponentModel.DataAnnotations;

namespace Encyklopediaa.Models.Objects
{
    public class Multimedia
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Type { get; set; }

        [Required]
        public string URL { get; set; }

        [Required]
        public string Description { get; set; }

        //public Artykuł? Artykul {  get; set; }

    }
}
