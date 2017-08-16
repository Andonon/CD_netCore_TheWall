using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using DbConnection;
using thewall.Models;
using System.Linq;

namespace thewall.Controllers
{
    public class HomeController : Controller
    {
        // GET: /Home/
        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            ViewBag.RegErrors = new List<string>();
            return View();
        }

        [HttpPost]
        [Route("register")]
        public IActionResult Register(string firstname, string lastname, string email, string username, string password, string cpassword)
        {
            Console.WriteLine("In HOME CONTROLLER Register method ==============================");

            User NewUser = new User
            {
                FirstName = firstname,
                LastName = lastname,
                UserName = username,
                Email = email, 
                Password = password,
                cPassword = cpassword
            };
        
            TryValidateModel(NewUser); 

            if(ModelState.IsValid){
                var CurrUsers = DbConnector.Query("SELECT * FROM users");
                foreach(var user in CurrUsers){
                    Console.WriteLine(user[0]).ToString());
                }

                string query = $"INSERT INTO users (firstname, lastname, email, username, password, created_at, updated_at) VALUES ('{firstname}', '{lastname}', '{email}', '{username}', '{password}', NOW(), NOW());";
                DbConnector.Execute(query);


                

            // // DB Query to get user id. and name
            // Sace to Session. 
                return View("~/Views/Message/Message.cshtml");    
            } 
            else 
            {
                ViewBag.RegErrors = ModelState.Values;
                ViewBag.FirstName = firstname;
                ViewBag.LastName = lastname;
                ViewBag.UserName = username;
                ViewBag.Email = email; 
                ViewBag.Password = password;
                ViewBag.cPassword = cpassword;
                return View("index");
            }
        }

        [HttpPost]
        [Route("login")]
        public IActionResult Login()
        {
            Console.WriteLine("In HOME CONTROLLER Login Method =======================");
            //check for user account and session data here.... next create quotes controller to handle quotes and check for session...



            return View();
        }

        [HttpGet]
        [Route("logoutorm")]
        public IActionResult Logout()
        {
            //check for user account and session data here.... CLEAR IT and return to login page....
            return View();
        }


    }
}
