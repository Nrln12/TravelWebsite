using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TravelWebsite.Models.Classes
{
    public class Comment
    {
        [Key]
        public int ID { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string CommentDetailed { get; set; }
        public int BlogId { get; set; }
        public virtual Blog Blog { get; set; }
    }
}