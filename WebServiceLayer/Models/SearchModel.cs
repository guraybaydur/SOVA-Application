using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DomainModel;

namespace WebServiceLayer.Models
{
    public class SearchModel
    {
        public string Url { get; set; }
        public int Id { get; set; }
        public int PostTypeId { get; set; }
        public int? ParentId { get; set; }
        public int? AcceptedAnswerId { get; set; }
        public DateTime CreationDate { get; set; }
        public int Score { get; set; }
        public string Body { get; set; }
        public DateTime? ClosedDate { get; set; }
        public string Title { get; set; }
        public string Tags { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }

        //variable for searching
        public float rankPoint = 0;
    }
}