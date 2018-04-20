using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LibraryAPI.Models
{
    public class CheckOutLedger
    {
        public int ID { get; set; }
        public  DateTime Timestamp { get; set; }
        public string EmailOfPerson { get; set; }

        public int BookID { get; set; }
        public Book Book { get; set; }
    }
}



//IHttpRequest
//    [Attribute]
//    is book checked out?
//    if it is give error message:
//    {
//        - declare vars 
//        - who = email.id
//        - timestamp = timestamp.now?
//        - will be returned in timestamp.now + 10 days
//    }