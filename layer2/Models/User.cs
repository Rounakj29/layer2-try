using System.ComponentModel.DataAnnotations;

namespace layer2.Models
{
    public class User
    {
        [Key]
        public int id { get; set; }
        [Required]
        public string name { get; set; }
        public int age { get; set; }

        public DateTime created =DateTime.Now;
    }
}
