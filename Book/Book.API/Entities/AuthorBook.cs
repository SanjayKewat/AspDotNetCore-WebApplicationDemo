using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Book.API.Entities
{
    [Table("Books")]
    public class AuthorBook
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [MaxLength(150)]
        public string Title { get; set; }

        [MaxLength(2500)]
        public string Description { get; set; }

        public Guid AuthorId { get; set; }  //Foregin key type used
        public Author Author { get; set; }  //Navigation
    }
}
