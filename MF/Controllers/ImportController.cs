using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MF.Controllers
{
    //ToDo: Read http://www.hanselman.com/blog/ABackToBasicsCaseStudyImplementingHTTPFileUploadWithASPNETMVCIncludingTestsAndMocks.aspx
    public class ImportController : Controller
    {
        //
        // GET: /Import/

        public ActionResult Index()
        {

            return View();
        }

        public ActionResult UploadFiles()
        {

            //Todo: ...
            return View();
        }
    }
}
