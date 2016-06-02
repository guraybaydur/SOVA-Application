using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using DataAccessLayer;
using DomainModel;

namespace WebServiceLayer.Controllers
{
    public class BaseApiController : ApiController
    {
        public object GetResultWithPaging<T>(IEnumerable<T> data, int pagesize, int page, int total, string route)
        {
            var lastpage = total / pagesize;

            var prev = page <= 0 ? null : Url.Link(route, new { page = page - 1, pagesize });
            var next = page >= lastpage ? null : Url.Link(route, new { page = page + 1, pagesize });

            //if (postId != 0)
            //{
            //    next = page >= lastpage ? null : Url.Link(route, new {  page = page + 1, pagesize });
            //    prev = page <= 0 ? null : Url.Link(route, new { page = page - 1, pagesize });
            //}

            //if (route == Util.Util.Config.SearchRoute)
            //{
            //    next = page >= lastpage ? null : Url.Link(route, new {PostId = postId, page = page + 1, pagesize});
            //    prev = page <= 0 ? null : Url.Link(route, new  {PostId =postId, page = page - 1, pagesize});
            //}



            var result = new
            {
                Total = total,
                Prev = prev,
                Next = next,
                Data = data
            };
            return result;
        }
    }
}
