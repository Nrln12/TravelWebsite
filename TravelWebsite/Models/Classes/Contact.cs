using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TravelWebsite.Models.Classes
{
    public class Contact
    {
        [Key]
        public int ID { get; set; }

        public string NameLastname { get; set; }
        public string Email { get; set; }
        public string Subject { get; set; }
        public string Message { get; set; }
    }
}