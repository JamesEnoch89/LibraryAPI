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
        public IHttpActionResult Get([FromUri]BookSearch data)
        {
            // search for book by title, author, or genre.
            // bind author and genre params to book search
            // fromuri = force web api to read complex data type (object)
            var db = new LibraryContext();
            var bookQuery = db.Books.Include(i => i.Author).Include(i => i.Genre);
            // if string has any params from BookSearch class, return them.
            if (!String.IsNullOrEmpty(data.Title))
            {
                bookQuery = bookQuery.Where(w => w.Title.Contains(data.Title));
            }

            if (!String.IsNullOrEmpty(data.Author))
            {
                bookQuery = bookQuery.Where(w => w.Author.Name.Contains(data.Author));
            }
            if (!String.IsNullOrEmpty(data.Genre))
            {
                bookQuery = bookQuery.Where(w => w.Genre.Name.Contains(data.Genre));
            }
            var results = bookQuery.ToList();
            if (results.Count == 0)
            {
                return NotFound();
            }
            else
            {
                return Ok(results);
            }
        }
        //[HttpGet]
        //public IEnumerable<Book> SearchLibrary()
        //// reuse search to display available books
        //{
        //    var db = new LibraryContext();
        //    var librarySearch = db.Books.Include(i => i.Author).Include(i => i.Genre);
        //    var rv = librarySearch.Where(book => book.IsCheckedOut == false);
        //    return rv.ToList();
        //}
    }
}
