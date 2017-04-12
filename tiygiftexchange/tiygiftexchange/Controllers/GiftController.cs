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
        //this is my get for my putpost. 
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        //create new gift
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
           
            var newGift = new Gift {
                Contents = collection["Contents"],
                GiftHint = collection["GiftHint"],
                ColorWrappingPaper = collection["ColorWrappingPaper"],
                Height = int.Parse(collection["Height"]),
                Width = int.Parse(collection["Width"]),
                Depth = int.Parse(collection["Depth"]),
                Weight = int.Parse(collection["Weight"]),
                IsOpened = bool.Parse(collection["IsOpened"])

            };
            // TODO: Put into db
            new GiftServices().AddGift(newGift);
            return RedirectToAction("Index");
        }

        //edit gift
        [HttpPost]
        public ActionResult Edit(int id, Gift gift)
        {
            var editedGift = gift.Id;
            new GiftServices().EditGift(gift);
            return RedirectToAction("Edit");
        }

        //delete gift
        [HttpPost]
        public ActionResult Delete(int id)
        {
            // TODO: build this
            return View("Index");
        }
    }
    
}