using System.ComponentModel.DataAnnotations;

namespace Something.Models
{
    public class People
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Company { get; set; }
        public string Address { get; set; }
        public string Telephone { get; set; }
    }
}
