using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Http;
using System.Security.Policy;
using System.Web.Http;
using System.Web.Http.Results;
using System.Web.Http.Routing;
using DataAccessLayer;
using DomainModel;
using Moq;
using NUnit.Framework;
using WebServiceLayer.Controllers;
using WebServiceLayer.Models;
using WebServiceLayer;
using WebServiceLayer.Util;
using Assert = NUnit.Framework.Assert;




namespace SovaApp.Tests.UnitTests
{
    //kk
    public class TestHistoryController
    {
        public Mock<IRepository> RepositoryMock;
        public Mock<BaseApiController> BaseApiMock;
        public Mock UrlHelperMock { get; set; }

        [SetUp]
        public void SetUp()
        {
            BaseApiMock = new Mock<BaseApiController>();
            RepositoryMock = new Mock<IRepository>();
            UrlHelperMock = new Mock<UrlHelper>();
        }

        [Test]
        public void GetAHistory_WithValidId_ReturnOk()
        {
            RepositoryMock.Setup(x => x.GetAHistory(It.IsAny<int>())).Returns(new History { Statement = "DENEME" });

            var controller = new HistoryController(RepositoryMock.Object);
            controller.Url = (UrlHelper)UrlHelperMock.Object;

            var response = controller.GetAHistory(12) as OkNegotiatedContentResult<HistoryModel>;

            Assert.NotNull(response);

        }

        [Test]
        public void GetAHistory_WithValidId_MakeCallToMySqlsGetAHistory()
        {
            //Arrange
            RepositoryMock.Setup(m => m.GetAHistory(It.IsAny<int>()))
                .Returns(new History { Statement = "Test" });

            var controller = new HistoryController(RepositoryMock.Object);
            controller.Url = (UrlHelper)UrlHelperMock.Object;

            //Act
            controller.GetAHistory(9);

            //Assert
            RepositoryMock.Verify(m => m.GetAHistory(It.Is<int>(x => x == 9)), Times.Once);
            //RepositoryMock.Verify(m => m.GetById(It.Is<int>(x => x == 1)), Times.Once);
        }

        [Test]
        public void GetAHistory_WithInvalidId_ReturnNotfound()
        {
            //Arrange
            var controller = new HistoryController(RepositoryMock.Object);
            //Act
            var response = controller.GetAHistory(-1) as NotFoundResult;
            //Assert
            Assert.NotNull(response);
        }

        [Test]
        public void PostAHistory_WithValidHistory_ReturnOk()
        {
            RepositoryMock.Setup(x => x.AddToHistory(It.IsAny<History>()));
            var controller = new HistoryController(RepositoryMock.Object);


            controller.Url = (UrlHelper)UrlHelperMock.Object;
            var historyModel = new HistoryModel
            {
                Id = 9,
                SearchDate = DateTime.Now,
                Statement = "not"
            };
            //var history = new History{Id=9,SearchDate = DateTime.Now, Statement = "not"};
            var response = controller.PostAHistory(historyModel) as CreatedNegotiatedContentResult<HistoryModel>;

            Assert.NotNull(response);

            Assert.AreEqual(Util.Config.HistoriesRoute, response.Location.ToString());


        }

        [Test]
        public void PostAHistory_WithValidHistory_MakeCallToAddHistory()
        {
            RepositoryMock.Setup(x => x.AddToHistory(It.IsAny<History>())).Callback<History>(h => h.Id = 10);

            var controller = new HistoryController(RepositoryMock.Object)
            {
                Configuration = new HttpConfiguration(),
                Request = new HttpRequestMessage { RequestUri = new Uri("http://localhost/api/history") }
            };
            WebApiConfig.Register(controller.Configuration);

            var historyModel = new HistoryModel { Statement = "Deneme" };

            var response = controller.PostAHistory(historyModel) as CreatedNegotiatedContentResult<HistoryModel>;

            Assert.NotNull(response);
            Assert.AreEqual("http://localhost/api/history/10", response.Content.Url);
            RepositoryMock.Verify(x => x.AddToHistory(It.Is<History>(h => h.Id == 10 && h.Statement == "Deneme")));
        }
        //[Test]
        //public void GetAllHistory_ReturnOk<T>()
        //{

        //    RepositoryMock.Setup(x => x.GetAllHistory(It.IsAny<int>(), It.IsAny<int>())).Returns(new List<History>());
        //    RepositoryMock.Setup(x => x.GetNumberOfHistories()).Returns(It.IsAny<int>());
        //    BaseApiMock.Setup(x => x.GetResultWithPaging<History>(It.IsAny<IEnumerable<History>>(),
        //        It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>()
        //        )).Returns(new { data = It.IsAny<IEnumerable<T>>(), pagesize = It.IsAny<int>(), page = It.IsAny<int>(),total = It.IsAny<int>(), route = It.IsAny<string>()});

        //    var controller = new HistoryController(RepositoryMock.Object);
        //    controller.Url = (UrlHelper)UrlHelperMock.Object;

        //    var response = controller.GetAllHistory(10, 5) as OkNegotiatedContentResult<HistoryModel>;
        //    Assert.NotNull(response);
        //    Assert.IsInstanceOf(new List<History>().GetType(), response.Content);
        //}
    }

}