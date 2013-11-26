using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MF.Models.Entities;
using NHibernate.Mapping;

namespace MF.Controllers
{
    public class TopController : Controller
    {

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetStandings()
        {
            var result = Json(new{
                aaData = Standing.Of().Select(
                x => new IComparable[]{ x.TeamName, x.TeamW, x.TeamD, x.TeamL, x.TeamF, x.TeamA })
            }, JsonRequestBehavior.AllowGet);
            return result;
        }
    }
}
