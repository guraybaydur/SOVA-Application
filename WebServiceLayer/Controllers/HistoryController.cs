using System.Linq;
using System.Web.Http;
using DataAccessLayer;
using DomainModel;
using WebServiceLayer.Models;
using WebServiceLayer.Controllers;
using WebServiceLayer.Util;


namespace WebServiceLayer.Controllers
{
    public class HistoryController : BaseApiController
    {

        private readonly IRepository _repository;

        public HistoryController(IRepository repository)
        {
            this._repository = repository;
        }

        [HttpGet]
        public IHttpActionResult GetAllHistory(int page = 0, int pagesize = Util.Util.Config.DefaultPageSize)
        {
            var data = _repository.GetAllHistory(pagesize, page * pagesize).Select(h => ModelFactory.Map(h, Url));

            var result = GetResultWithPaging(
                data,
                pagesize,
                page,
                _repository.GetNumberOfHistories(),
                Util.Util.Config.HistoriesRoute);

            if (result == null)
                return NotFound();

            return Ok(result);

        }

        [HttpGet]
        public IHttpActionResult GetAHistory(int id)
        {

            var historyModel = ModelFactory.Map(_repository.GetAHistory(id), Url);

            if (historyModel == null)
                return NotFound();

            return Ok(historyModel);
        }

        [HttpPost]
        public IHttpActionResult PostAHistory(HistoryModel history)
        {
            var historyObject = new History { Id = history.Id, SearchDate = history.SearchDate, Statement = history.Statement };
            _repository.AddToHistory(historyObject);

            return Created(Util.Util.Config.HistoriesRoute, ModelFactory.Map(historyObject, Url));
        }

        [HttpDelete]
        public IHttpActionResult DeleteAHistory(int id)
        {
            _repository.DeleteFromHistory(id);
            return Ok();
        }

        [HttpDelete]
        public IHttpActionResult DeleteAllHistory()
        {
            _repository.DeleteAllHistory();
            return Ok();
        }


    }

}
