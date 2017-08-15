using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using DbConnection;
using System.Linq;

namespace thewall.Controllers
{
    public class MessageController : Controller
    {
        [HttpGet]
        [Route("/Messages")]
        public IActionResult Messages(){
            //Get all quotes
            string query = "SELECT * FROM messages";
            var messages = DbConnector.Query(query);

            // //Sort them by created time descending
            // messages = messages.OrderByDescending((message) => messages["created_at"]).ToList();

            //Format all of the dates
            foreach(var message in messages){
                DateTime created = (DateTime)message["created_at"];
                string formatted_created = String.Format("{0:h:mm tt MMMM d yyyy}", created);
                message["created_at"] = formatted_created;
            }

            ViewBag.Messages = messages;
            return View();
        }
    }
}
