using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LibraryRentingApp.Models
{
    public class Book
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public string Description { get; set; } = null!;
        public string Author { get; set; } = null!;
        [ForeignKey("CustomerId")]
        public int? CustomerId { get; set; }
  
        public Book(string title, string description, string author)
        {
            Title = title;
            Description = description;  
            Author = author;
        }
    }
}
