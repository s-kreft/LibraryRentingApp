using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace LibraryRentingApp.Models
{
    public class Book
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public string Description { get; set; } = null!;
        public string Author { get; set; } = null!;
  
        public Book(int id, string title, string description, string author)
        {
            Id = id;
            Title = title;
            Description = description;  
            Author = author;
        }
    }
}
