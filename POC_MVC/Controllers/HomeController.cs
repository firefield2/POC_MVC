using MongoDB.Bson;
using POC_MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace POC_MVC.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            Repository<Person> db = new Repository<Person>("persons");
            List<Person> list = db.List().ToList();
            return View(list);
        }

        public ActionResult ShowPerson(ObjectId personId)
        {
            Repository<Person> db = new Repository<Person>("persons");
            Person person = db.FindById(personId);
            return View(person);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}