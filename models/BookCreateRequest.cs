using System.ComponentModel.DataAnnotations;

public class BookCreateRequest
{
    [Required(ErrorMessage = "Title is required")]
    [MinLength(1, ErrorMessage = "Title must be between 1 and 100 characters")]
    [MaxLength(100, ErrorMessage = "Title must be between 1 and 100 characters")]
    public string Title { get; set; }

    [Required(ErrorMessage = "Genre is required")]
    [MinLength(1, ErrorMessage = "Genre must be between 1 and 50 characters")]
    [MaxLength(50, ErrorMessage = "Genre must be between 1 and 50 characters")]
    public string Genre { get; set; }

    [Required(ErrorMessage = "AuthorId is required")]
    public string AuthorId { get; set; }
}
