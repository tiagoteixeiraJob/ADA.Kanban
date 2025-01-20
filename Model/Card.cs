using System.ComponentModel.DataAnnotations;

namespace Model
{
    public class Card
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Field 'Title' cannot be null!")]
        public string? Title { get; set; }

        [Required(ErrorMessage = "Field 'Content' cannot be null!")]
        public string? Content { get; set; }

        [Required(ErrorMessage = "Field 'List' cannot be null!")]
        public string? List { get; set; }
    }
}
