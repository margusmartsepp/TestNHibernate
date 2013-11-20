using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MF.Models;

namespace MF.Controllers
{
    public class TeamController : Controller
    {
        DataClassesDataContext db = new DataClassesDataContext();
        //
        // GET: /Team/

        public ActionResult Index()
        {
            var tList = new List<Team>();
            tList.AddRange(from c in db.Teams select c);
            return View(tList);
        }

        //
        // GET: /Team/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /Team/Create

        [HttpPost]
        public ActionResult Create([Bind(Exclude="Id")]Team teamToCreate)
        {
            try
            {
                db.Teams.InsertOnSubmit(teamToCreate);
                db.SubmitChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        
        //
        // GET: /Team/Edit/5
 
        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /Team/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, [Bind(Exclude="Id")]Team teamToEdit)
        {
            try
            {
                Team teamEdit =
                  db.Teams.Single(c => c.Id == id);
                teamEdit.TeamName = teamToEdit.TeamName;
                db.SubmitChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Team/Delete/5
 
        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Team/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, [Bind(Exclude = "Id")]Team teamToEdit)
        {
            try
            {
                Team teamEdit =
                  db.Teams.Single(c => c.Id == id);
                db.Teams.DeleteOnSubmit(teamEdit);
                db.SubmitChanges();
 
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
