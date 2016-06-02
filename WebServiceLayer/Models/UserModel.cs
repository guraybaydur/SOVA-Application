using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebServiceLayer.Models
{
    public class UserModel
    {
        public string Url { get; set; }
        public int? Id { get; set; }
        public string DisplayName { get; set; }
        public DateTime CreationDate { get; set; }
        public string Location { get; set; }
        public int? Age { get; set; }
    }
}