using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LibraryRentingApp.Models
{
    public class Customer
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Address { get; set; } = null!;
        public string City { get; set; } = null!;
        public ICollection<Book> RentedBooks { get; } = new List<Book>();

        public Customer()
        {

        }

        public Customer(string name, string adress, string city)
        {
            Name = name;
            Address = adress;
            City = city;
        }
    }
}
