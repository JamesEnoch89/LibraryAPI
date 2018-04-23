using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using LibraryAPI.Data;
using LibraryAPI.Models;
using LibraryAPI.ViewModels;

namespace LibraryAPI.Controllers
{
    public class BookController : ApiController
    {

        public IEnumerable<Book> GetAllBooks()
        {
            var db = new LibraryContext();
            return db.Books.ToList();
        }

        // post new book
        // not pulling in author name or genre name?
        // save issue as friday
        public IHttpActionResult Post(BookPost book)
        {
            var dbBook = new LibraryContext();

            Author author = dbBook.Authors.First(f => f.Name == book.AuthorName);
            Genre genre = dbBook.Genres.First(f => f.Name == book.GenreName);

            var newBook = new Book
            {
                Title = book.Title,
                YearPublished = book.YearPublished,
                Condition = book.Condition,
                AuthorID = author.ID,
                GenreID = genre.ID,
                IsCheckedOut = book.IsCheckedOut,
            };

            dbBook.Books.Add(newBook);
            dbBook.SaveChanges();
            newBook.Author = author;
            newBook.Genre = genre;
            return Ok(newBook);
        }
    }
}