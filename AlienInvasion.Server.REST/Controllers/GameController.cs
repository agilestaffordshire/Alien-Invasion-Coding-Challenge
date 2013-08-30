using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AlienInvasion.Server.REST.Models;

namespace AlienInvasion.Server.REST.Controllers
{
    public class GameController : ApiController
    {
        private static readonly IList<Game> Games = new List<Game>();

        [HttpPost]
        public HttpResponseMessage Create()
        {
            var game = new Game();
            Games.Add(game);
            var httpResponseMessage = new HttpResponseMessage(HttpStatusCode.Created);
            httpResponseMessage.Headers.Location = new Uri(string.Format("http://localhost/game/{0}", game.Id));
            return httpResponseMessage;
        }

        [HttpGet]
        public HttpResponseMessage Get(string id)
        {
            var game = Games.FirstOrDefault(x => x.Id == id);
            if (game != null)
                return new HttpResponseMessage(HttpStatusCode.OK);
            return new HttpResponseMessage(HttpStatusCode.NotFound);
        }
    }
}