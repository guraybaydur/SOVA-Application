using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel
{
    public class Mark
    {
        public int Id { get; set; }
        public int PostId { get; set; }
        public Post post { get; set; }
        public string Note { get; set; }


        public Mark(int _postid, string _note)
        {
            Id = 0;
            PostId = _postid;
            Note = _note;

        }

        public Mark()
        {
            Id = 0;
            PostId = 0;
            Note = "";

        }
    }
}
