using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LibraryAPI.ViewModels

    //use view model to pull in author and genre names 
    // bind them to new book post
{
    public class BookPost
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string YearPublished { get; set; }
        public string Condition { get; set; } //enum???
        public bool IsCheckedOut { get; set; }
        public DateTime DueBackDate { get; set; }
        public string AuthorName { get; set; }
        public string GenreName { get; set; }
    }
}