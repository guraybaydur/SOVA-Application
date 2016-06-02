using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Http.Results;
using DataAccessLayer;
using DomainModel;
using MySqlDatabase;
using WebServiceLayer.Models;
using WebServiceLayer.Controllers;
using WebServiceLayer.Util;

namespace WebServiceLayer.Controllers
{


    public class CommentController : BaseApiController
    {
        //public List<Comment> comments { get; set; }
        private readonly IRepository _repository;

        public CommentController(IRepository repository)
        {
            _repository = repository;
        }

        //string _previousPage = HttpContext.Current.Request.UrlReferrer.AbsolutePath;

        [HttpGet]
        [ActionName("GetCommentsOfAPost")]
        public IHttpActionResult GetCommentsOfAPost(int id, int page = 0, int pagesize = Util.Util.Config.DefaultPageSize)
        {
            var data = _repository.GetCommentsOfAPost(id, pagesize, page * pagesize).Select(c => ModelFactory.Map(c, Url));

            var result = GetResultWithPaging(
                data,
                pagesize,
                page,
                _repository.GetNumberOfCommentsOfAPost(id),
                Util.Util.Config.CommentsRoute);

            if (result == null)
                return NotFound();

            return Ok(result);
        }
    }
}
