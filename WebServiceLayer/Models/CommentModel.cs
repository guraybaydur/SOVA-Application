﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DomainModel;

namespace WebServiceLayer.Models
{
    public class CommentModel
    {
        public string Url { get; set; }
        public int Id { get; set; }
        public int PostId { get; set; }
        public int Score { get; set; }
        public string Text { get; set; }
        public DateTime CreationDate { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
    }
}