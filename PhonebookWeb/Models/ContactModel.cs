using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PhonebookWeb.Models
{
    public class ContactModel
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Number { get; set; }
    }
}