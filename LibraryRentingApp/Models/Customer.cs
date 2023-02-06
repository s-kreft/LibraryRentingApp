using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace LibraryRentingApp.Models
{
    public class Customer
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Address { get; set; } = null!;
        public string City { get; set; } = null!;
        public List<Book> RentedBooks { get; set; } = null!;

        public Customer()
        {

        }
    }
}
