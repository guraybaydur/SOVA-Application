using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebServiceLayer.Models
{
    public class HistoryModel
    {
        public string Url { get; set; }
        public int Id { get; set; }
        public string Statement { get; set; }
        public DateTime SearchDate { get; set; }

        public HistoryModel(string _statement)
        {
            Statement = _statement;
            Id = 0;
            SearchDate = DateTime.Now;
        }

        public HistoryModel()
        {
            Statement = "";
            Id = 0;
            SearchDate = DateTime.Now;
        }
    }
}