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
using Moq;//
using NUnit.Framework;
using WebServiceLayer.Controllers;
using MySqlDatabase;
using WebServiceLayer.Models;
using Assert = NUnit.Framework.Assert;

namespace WebServiceLayer.Test.IntegrationTests
{
    public class TestMySqlRepository
    {
        [Test]
        public void GetAPost_WithValidPostId_ReturnPost()
        {
            var service = new MySqlRepository();//

            var result = service.GetAPost(19);

            Assert.AreEqual(result.UserId, 13);
        }
        [Test]
        public void DeleteFromHistory_Id_RemoveHistory()
        {
            //Arrange
            var service = new MySqlRepository();
            var history = new History { Id = 80, Statement = "helloooo", SearchDate = DateTime.Now };
            service.AddToHistory(history);
            //int id = history.Id.Value;
            //Act
            service.DeleteFromHistory(history.Id);

            //Assert
            Assert.Null(service.GetAHistory(history.Id));
        }
        [Test]
        public void AddToHistory_WithValidHistory()
        {
            //Arrange
            var service = new MySqlRepository();
            var history2 = new History { Id = 80, Statement = "helloooo", SearchDate = DateTime.Now };
            //Act
            service.AddToHistory(history2);

            //Assert
            Assert.AreEqual("helloooo", service.GetAHistory(history2.Id).Statement);

            //CleanUp//
            service.DeleteFromHistory(history2.Id);

        }

    }
}