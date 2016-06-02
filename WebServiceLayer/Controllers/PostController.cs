using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using DataAccessLayer;
using WebServiceLayer.Models;

namespace WebServiceLayer.Controllers
{
    public class PostController : ApiController
    {
        private readonly IRepository _repository;

        public PostController(IRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        [ActionName("GetAPost")]
        public IHttpActionResult GetAPost(int postId)
        {
            var postModel = ModelFactory.Map(_repository.GetAPost(postId), Url);

            if (postModel == null)
            {
                return NotFound();
            }
            return Ok(postModel);
        }


        [HttpGet]
        [ActionName("GetRelatedPosts")]
        public IHttpActionResult GetRelatedPosts(int postId)
        {
            var postModel = _repository.GetAllRelatedPosts(postId);

            if (postModel == null)
            {
                return NotFound();
            }
            return Ok(postModel);
        }
    }
}

