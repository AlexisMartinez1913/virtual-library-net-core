using System.ComponentModel.DataAnnotations;

namespace VirtualLibrary.Models.Entities
{
    public class Book
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Title is required")]
        public string Title { get; set; }
        [Required(ErrorMessage = "Author is required")]
        public string Author { get; set; }
        [Required(ErrorMessage = "Published year is required")]
        public string PublishedYear { get; set; }
        [Required(ErrorMessage = "Genre is required")]
        public string Genre { get; set; }
        public int AvailableCopies { get; set; }
    }
}
