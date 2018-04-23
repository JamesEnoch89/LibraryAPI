using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

using LibraryAPI.Models;
using LibraryAPI.Data;
using LibraryAPI.ViewModels;

namespace LibraryAPI.Controllers
{
    public class AuthorController : ApiController
    {
        public IEnumerable<Author> GetAllAuthors()
        {
            var db = new LibraryContext();
            return db.Authors.ToList();
        }

        public Author Post(Author newAuthor)
        {
            var dbAuthor = new LibraryContext();
            dbAuthor.Authors.Add(newAuthor);
            dbAuthor.SaveChanges();
            return newAuthor;
        }
    }
}
