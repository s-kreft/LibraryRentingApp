
using LibraryRentingApp.Controllers;
using LibraryRentingApp.Models;
using Xunit;

namespace TestProject1
{
    public class LibraryRentingServiceTest
    {
        [Fact]
        public void PostBookToDb_Is_Book_Added_To_Db()
        {
            //Arrange
            var book = new Book(1, "The Lord of the Rings", "Fantasy Novel", "J.R.R. Tolkien");
            var controller = new LibraryRentingController();
            //Act
            controller.PostBookToDb(book);
            var testbook = controller.GetBookFromDb(book.Title);

            //Assert
            Assert.Equal(testbook, book.Title);


        }
    }
}