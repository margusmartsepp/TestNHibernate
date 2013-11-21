using System;
using System.Collections.Generic;
using System.Data.SqlServerCe;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MF.Models.Entities;
namespace MF.Controllers
{
    public class ResultController : Controller
    {
        //
        // GET: /Result/

        public ActionResult Index()
        {
            return View(Result.GetAllResults());
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Result resultToCreate)
        {
            try
            {
                var team1 = Team.GetTeamById(int.Parse(resultToCreate.ResultFirst.TeamName));
                var team2 = Team.GetTeamById(int.Parse(resultToCreate.ResultSecond.TeamName));
                var newresult = new Result { 
                    ResultFirst = team1, ResultFirstScore = resultToCreate.ResultFirstScore, 
                    ResultSecond = team2, ResultSecondScore = resultToCreate.ResultSecondScore };
                Result.Add(newresult);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Edit(int id)
        {
            return View(Result.GetResultById(id));
        }

        [HttpPost]
        public ActionResult Edit(int id, Result resultToEdit)
        {
            try
            {
                var team1 = Team.GetTeamById(int.Parse(resultToEdit.ResultFirst.TeamName));
                var team2 = Team.GetTeamById(int.Parse(resultToEdit.ResultSecond.TeamName));

                var current = Result.GetResultById(id);
                current.ResultFirst = team1;
                current.ResultFirstScore = resultToEdit.ResultFirstScore;
                current.ResultSecond = team2;
                current.ResultSecondScore = resultToEdit.ResultSecondScore;
                Result.Update(current);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Delete(int id)
        {
            return View();
        }


        [HttpPost]
        public ActionResult Delete(int id, [Bind(Exclude = "Id")]Team teamToEdit)
        {
            try
            {
                Result.Delete(Result.GetResultById(id));
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
