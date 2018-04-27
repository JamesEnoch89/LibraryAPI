using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using LibraryAPI.Data;
using LibraryAPI.Models;
using LibraryAPI.ViewModels;
using System.Data.Entity;

namespace LibraryAPI.Controllers
{
    public class BookController : ApiController
    {
        [Route("api/books")]
        [HttpGet]
        public IEnumerable<BookViewModel> GetAllBooks()
        {
            var db = new LibraryContext();
            var data = db.Books
                .Include(i => i.Author)
                .Include(i => i.Genre)
                .ToList();

            var rv = data.Select(book => new BookViewModel
            {
                Title = book.Title,
                AuthorName = book.Author.Name,
                GenreName = book.Genre.Name,
                YearPublished = book.YearPublished
            });
            return rv;
        }


        // post new book
        // not pulling in author name or genre name?
        // save issue as friday
        public IHttpActionResult Post(BookViewModel book)
        {
            var db = new LibraryContext();

            Author author = db.Authors.First(f => f.Name == book.AuthorName);
            Genre genre = db.Genres.First(f => f.Name == book.GenreName);

            var newBook = new Book
            {
                Title = book.Title,
                YearPublished = book.YearPublished,
                Condition = book.Condition,
                AuthorID = author.ID,
                GenreID = genre.ID,
                IsCheckedOut = book.IsCheckedOut,
            };

            db.Books.Add(newBook);
            db.SaveChanges();
            newBook.Author = author;
            newBook.Genre = genre;
            return Ok(newBook);
        }
    }
}