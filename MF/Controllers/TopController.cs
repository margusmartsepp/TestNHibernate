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
            return View(Standing.Of());
        }
    }
}
