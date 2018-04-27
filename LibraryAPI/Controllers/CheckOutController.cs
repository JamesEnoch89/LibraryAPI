using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using LibraryAPI.Data;
using LibraryAPI.ViewModels;
using LibraryAPI.Models;

namespace LibraryAPI.Controllers
{
    public class CheckOutController : ApiController
    {
        [HttpPut]
        [Route("api/checkout/{bookId}")]
        public CheckOutReceiptViewModel Put([FromUri]int bookID, [FromBody]CheckOutViewModel data)
        {
            var db = new LibraryContext();

            var book = db.Books.Single(s => s.ID == bookID);
            if (!book.IsCheckedOut)
            {
                book.IsCheckedOut = true;
                book.DueBackDate = DateTime.Now.AddDays(10);

                var newCheckout = new CheckOutLedger()
                {
                    Timestamp = DateTime.Now,
                    EmailOfPerson = data.EmailOfPerson,
                    BookID = book.ID,
                    Book = book
                };
                db.CheckOutLedger.Add(newCheckout);
                db.SaveChanges();

                return new CheckOutReceiptViewModel
                {
                    Message = "You have successfully checked this book out",
                    DueBackDate = book.DueBackDate
                };
            }
            else
            {
                return new CheckOutReceiptViewModel
                {
                    Message = "The book you are looking for is currently checked out",
                    DueBackDate = book.DueBackDate
                };
            }
        }


    }
}

