using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using tiygiftexchange.Models;
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
           
            var newGift = new Gift {
                Contents = collection["Contents"],
                GiftHint = collection["GiftHint"],
                ColorWrappingPaper = collection["ColorWrappingPaper"],
                Height = (object)collection["Height"] as int?,
                Width = (object)collection["Width"] as int?,
                Depth = (object)collection["Depth"] as int?,
                Weight = (object)collection["Weight"] as int?,
                IsOpened = (object)collection["IsOpened"] as bool?

            };
            // TODO: Put into db
            new GiftServices().AddGift(newGift);

            return RedirectToAction("Index");
        }
    }
    
}