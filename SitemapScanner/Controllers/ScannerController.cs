using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SitemapScanner.Scanner;

namespace SitemapScanner.Controllers
{
    public class ScannerController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        
        [HttpGet]
        public ActionResult GetSiteMapUrlAddress(string urlAddress)
        {
            try
            {
                List<string> urlList = new List<string>();
                if (!string.IsNullOrEmpty(urlAddress))
                {
                    var siteMap = new SiteMapReader();
                    urlList = siteMap.GetUrls(urlAddress).ToList();
                }
                else
                {
                    throw(new Exception("Please fill url address"));
                }
                return Json(urlList, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(string.Format("Error: {0}", ex));
            }
        }

        [HttpGet]
        public ActionResult GetPageTimeResponse(string urlAddress)
        {
            var pageTimeResponse = new PageTimeResponse();
            var response = pageTimeResponse.ExecuteTest(urlAddress);

            return Json(response, JsonRequestBehavior.AllowGet);
        }
    }
}