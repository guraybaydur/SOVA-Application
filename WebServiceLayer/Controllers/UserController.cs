using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using DataAccessLayer;
using MySqlDatabase;
using DomainModel;
using WebServiceLayer.Models;
using WebServiceLayer.Controllers;

namespace WebServiceLayer.Controllers
{

    public class UserController : BaseApiController
    {
        private readonly IRepository _repository;

        public UserController(IRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public IHttpActionResult GetUserById(int id)
        {
            var userModel = ModelFactory.Map(_repository.GetUserById(id), Url);


            if (userModel == null)
                return NotFound();

            return Ok(userModel);
        }



    }
}
