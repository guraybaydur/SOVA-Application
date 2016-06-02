using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DomainModel;

namespace WebServiceLayer.Models
{
    public class MarkModel
    {
        public string Url { get; set; }
        public int Id { get; set; }
        public int PostId { get; set; }
        public Post post { get; set; }
        public string Note { get; set; }

        public MarkModel(int _postid, string _note)
        {
            Id = 0;
            PostId = _postid;
            Note = _note;

        }

        public MarkModel()
        {
            Id = 0;
            PostId = 0;
            Note = "";

        }
    }
}