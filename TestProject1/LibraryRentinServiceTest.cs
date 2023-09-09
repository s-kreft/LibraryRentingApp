
using LibraryRentingApp.Controllers;
using LibraryRentingApp.Models;
using Xunit;
using Moq;
using LibraryRentingApp.Services;
using LibraryRentingApp.Repository;

namespace TestProject1
{
    public class LibraryRentingServiceTest
    {
        //[Fact]
        //public void PostBookToDb_Is_Book_Added_To_Db()
        //{
        //    //Arrange
        //    var book = new Book(1, "The Lord of the Rings", "Fantasy Novel", "J.R.R. Tolkien");
        //    var controller = new LibraryRentingController();
        //    //Act
        //    controller.PostBookToDb(book);
        //    var testbook = controller.GetBookFromDb(book.Title);

        //    //Assert
        //    Assert.Equal(testbook, book.Title);


        //}
        [Fact]
        public void AddBookToDb_BookIsAddedToDb_BookSuccesfullyAdded()
        {           
            //Arrange
          
            var mock_dbContext = new Mock<LibraryRentingDbContext>();

            var book = new Book("The Lord of the Rings", "Fantasy Novel", "J.R.R. Tolkien");

            mock_dbContext.Setup(x => x.Add(It.IsAny<Book>()));

            var sut_libraRyrntingService = new LibraryRentingService(mock_dbContext.Object);

            //Act
            sut_libraRyrntingService.AddBookToDb(book);

            //Assert
            mock_dbContext.Verify(x => x.Add(book), Times.Once);
        }
    }
}