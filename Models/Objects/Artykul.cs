using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Encyklopediaa.Models.Objects
{
    public class Artykul
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        //[Required]
        //public string Treść { get; set; }


        //[Required]
        //public DataType DataPublication { get; set; }


        public string URL { get; set; }

        [NotMapped]
        public IFormFile Obraz { get; set; }

        [Required]
        public int UżytkownikId { get; set; }
        public virtual Użytkownik Użytkownik { get; set; }

        [Required]
        public int RodzinaID { get; set; }
        public virtual Rodzina Rodzina { get; set; }


        public int AdminId { get; set; }
        public virtual Admin Admin { get; set; }

        //[Required]
        //public int MultimediaId { get; set; }
        //public Multimedia Multimedia { get; set; }
    }
}
