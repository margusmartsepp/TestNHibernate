using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MF.Models;

namespace MF.Controllers
{
    public class TeamsController : Controller
    {
        DataClassesDataContext db = new DataClassesDataContext();
        /// <summary>
        /// Display list of teams
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            var tList = new List<Team>();
            tList.AddRange(from c in db.Teams select c);
            return View(tList);
        }
        /// <summary>
        /// Display a form for creating a new team
        /// </summary>
        /// <returns></returns>
        public ActionResult Create()
        {
            return View();
        }

        /// <summary>
        /// Add new item to database
        /// </summary>
        /// <returns></returns>
        public ActionResult CreateNew(String team)
        {
            Team newTeam = new Team(){
                TeamName = team
            };
           
            db.Teams.InsertOnSubmit(newTeam);
            db.SubmitChanges();

            return RedirectToAction("Index");
        }
    }
}
