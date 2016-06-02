
using System.Linq;

using System.Web.Http;
using DataAccessLayer;
using MySqlDatabase;
using DomainModel;
using WebServiceLayer.Models;
using WebServiceLayer.Controllers;
using WebServiceLayer.Util;

namespace WebServiceLayer.Controllers
{
    public class MarkController : BaseApiController
    {
        private readonly IRepository _repository;

        public MarkController(IRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public IHttpActionResult GetAllMarkedPosts(int page = 0, int pagesize = Util.Util.Config.DefaultPageSize)
        {
            var data = _repository.GetMarkedPosts(pagesize, page * pagesize).Select(m => ModelFactory.Map(m, Url));

            var result = GetResultWithPaging(
                data,
                pagesize,
                page,
                _repository.GetNumberOfMarkedPosts(),
                Util.Util.Config.MarksRoute);


            if (result == null)
                return NotFound();


            return Ok(result);
        }

        [HttpGet]
        public IHttpActionResult GetAMark(int markId)
        {
            var markModel = ModelFactory.Map(_repository.GetAMark(markId), Url);

            if (markModel == null)
            {
                return NotFound();
            }
            return Ok(markModel);
        }

        [HttpPost]
        public IHttpActionResult MarkAPost(Mark mark)
        {
            _repository.Mark(mark);
            return Created(Util.Util.Config.PostsRoute, ModelFactory.Map(mark, Url));
        }

        [HttpDelete]
        public IHttpActionResult DeleteAMark(int id)
        {
            _repository.Unmark(id);
            return Ok();
        }

        [HttpDelete]
        public IHttpActionResult DeleteAllMarks()
        {
            _repository.DeleteAllMarks();
            return Ok();
        }
    }
}
