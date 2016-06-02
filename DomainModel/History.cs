using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel
{
    public class History
    {




        public int? Id { get; set; }
        public string Statement { get; set; }
        public DateTime? SearchDate { get; set; }

        public History(string _statement)
        {
            Statement = _statement;
            Id = 0;
            SearchDate = DateTime.Now;
        }

        public History()
        {
            Statement = "";
            Id = 0;
            SearchDate = DateTime.Now;
        }
    }


}
