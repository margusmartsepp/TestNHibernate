using System.Web.Mvc;
using MF.Models.Entities;

namespace MF.Controllers
{
    public class TeamController : Controller
    {

        public ActionResult Index()
        {
            return View(Team.GetAllTeams());
        }



        public ActionResult Create()
        {
            return View();
        } 

        [HttpPost]
        public ActionResult Create([Bind(Exclude="Id")]Team teamToCreate)
        {
            try
            {
                Team.Add(teamToCreate);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
 
        public ActionResult Edit(int id)
        {
            return View(Team.GetTeamById(id));
        }

        [HttpPost]
        public ActionResult Edit(int id, [Bind(Exclude="Id")]Team teamToEdit)
        {
            try
            {
                var current = Team.GetTeamById(id);
                current.TeamName = teamToEdit.TeamName;
                Team.Update(current);
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
                Team.Delete(Team.GetTeamById(id));
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
