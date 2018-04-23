using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using LibraryAPI.Data;
using LibraryAPI.Models;
using LibraryAPI.ViewModels;

namespace LibraryAPI.Controllers
{
    public class SearchController : ApiController
    {
        [HttpGet]
        public IEnumerable<Book> Search([FromUri]BookSearch book)
        {
            // search for book by title, author, or genre.
            // bind author and genre params to book search
            // fromuri = force web api to read complex data type (object)
            var db = new LibraryContext();
            var bookSearch = db.Books.Include(i => i.Author).Include(i => i.Genre);
            // if string has any params from BookSearch class, return them.
            if (!String.IsNullOrEmpty(book.Title))
            {
                bookSearch = bookSearch.Where(w => w.Title == book.Title);
            }

            if (book.Author != null)
            {
                bookSearch = bookSearch.Where(w => w.Author.Name == book.Author);
            }
            if (book.Genre != null)
            {
                bookSearch = bookSearch.Where(w => w.Genre.Name == book.Genre);
            }
            return bookSearch;
        }

        [HttpGet]
        public IEnumerable<Book> SearchLibrary()
        // reuse search to display available books
        {
            var db = new LibraryContext();
            var librarySearch = db.Books.Include(i => i.Author).Include(i => i.Genre);
            var rv = librarySearch.Where(book => book.IsCheckedOut == false);
            return rv.ToList();
        }
    }
}
