using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using AlienInvasion.Server.REST.Controllers;
using NUnit.Framework;

namespace AlienInvasion.Server.REST.Tests
{
    [TestFixture]
    public class GameControllerTests
    {
        [Test]
        public void WhenCreatingANewGameThenStatusCodeReturnedCreated()
        {
            var controller = new GameController();
            HttpResponseMessage response = controller.Create();
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.Created));
        }

        [Test]
        public void WhenCreatingANewGameThenLocationHeaderPointsToGameUri()
        {
            var controller = new GameController();
            HttpResponseMessage response = controller.Create();
            StringAssert.EndsWith("/game/1", response.Headers.Location.ToString());
        }

        [Test]
        public void WhenRetrievingAGameThatDoesNotExistReturnsStatusCodeNotFound()
        {
            var controller = new GameController();
            var response = controller.Get("A");
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.NotFound));
        }

        [Test]
        public void WhenRetrievingAnExistingGameReturnsStatusCodeOk()
        {
            var controller = new GameController();
            HttpResponseMessage createResponse = controller.Create();
            HttpResponseMessage response = controller.Get(createResponse.Headers.Location.ToString().Last().ToString());
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        }
    }
}
