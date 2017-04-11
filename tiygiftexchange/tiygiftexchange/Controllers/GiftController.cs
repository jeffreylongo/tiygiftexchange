using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using tiygiftexchange.Services;

namespace tiygiftexchange.Controllers
{
    public class GiftController : Controller
    {
        // GET: Gift
        public ActionResult Index()
        {
            //get all gifts
            var gifts = new GiftServices().GetAllGifts();
            //pass them to the view
            return View(gifts);
        } 

        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            //return View();
        }
    }
    
}