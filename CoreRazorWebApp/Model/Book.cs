using System.ComponentModel.DataAnnotations;

namespace CoreRazorWebApp.Model
{
    public class Book
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Autor { get; set; }
    }
}
