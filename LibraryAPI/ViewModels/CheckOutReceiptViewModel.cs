using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LibraryAPI.ViewModels
{
    public class CheckOutReceiptViewModel
    {
        public string Message { get; set; }
        public DateTime? DueBackDate { get; set; }
    }
}