﻿using LibraryRentingApp.Models;
using LibraryRentingApp.Repository;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace LibraryRentingApp.Services
{
    public class LibraryRentingService : ILibraryRentingService
    {
        private readonly LibraryRentingDbContext _dbContext;
        public LibraryRentingService()
        {

        }
        public LibraryRentingService(LibraryRentingDbContext dbContext)
        {
            _dbContext = dbContext;
            _dbContext.SaveChanges();
        }

        public async void AddBookToDb(Book book)
        {
            _dbContext.Add(book);
            _dbContext.SaveChanges();
        }

        public async IAsyncEnumerable<string>GetBookFromDb(string bookTitle)
        {

            var bookFromDb = _dbContext.books.FirstOrDefault(b => b.Title == bookTitle);
            var json = JsonConvert.SerializeObject(bookFromDb);
            yield return json;
        }

        public void UpdateBookInDb(Book book) 
        {

        }

        public async void DeleteBookFromDb(string bookTitle)
        {
            var bookToDelete = _dbContext.books.FirstOrDefault(b => b.Title == bookTitle);
            _dbContext.Remove(bookToDelete);
            _dbContext.SaveChanges();
        }

        public async void AddNewLibraryCustomer(Customer customer)
        {
            _dbContext.Add(customer);
            _dbContext.SaveChanges();
        }

        public async IAsyncEnumerable<Customer> GetCustomerFromDb(string customerName)
        {
            var customerFromDb = _dbContext.customers.FirstOrDefault(c => c.Name.Equals(customerName));
            yield return customerFromDb;
        }

        public async void DeleteCustomerFromDb(string customerName)
        {
            var customerToDelete = _dbContext.customers.FirstOrDefault(c => c.Name.Equals(customerName));
            _dbContext.Remove(customerToDelete);
            _dbContext.SaveChanges();
        }

        public async void AddBookToLibraryCustomer(string customerName, string bookTitle)
        {
            var customer = _dbContext.customers.FirstOrDefault(c => c.Name == customerName);

            IQueryable<Book> BookToCustomerQuerry =
                from book in _dbContext.books
                where book.Title == bookTitle
                select book;

            foreach(Book book in BookToCustomerQuerry)
            {
                book.CustomerId = customer.Id;
            }
                _dbContext.SaveChanges();
        }

        public async IAsyncEnumerable<List<Book>> GetBooksRentedByCustomer(int customerId)
        {
            var CustomerBookList= new List<Book>();

            IQueryable<Book> CustomerRentedBooks =
                from book in _dbContext.books
                where book.CustomerId == customerId
                select book;

            foreach(Book book in CustomerRentedBooks)
            {
                CustomerBookList.Add(book);
            }
            yield return CustomerBookList;
        }
    }
}