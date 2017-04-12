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

        //get gift for edit. 
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var gift = new GiftServices().GetGift(id);
            return View(gift);
        }

        //edit gift
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            var updatedGift = new Gift
            {
                Contents = collection["Contents"],
                GiftHint = collection["GiftHint"],
                ColorWrappingPaper = collection["ColorWrappingPaper"],
                Height = int.Parse(collection["Height"]),
                Width = int.Parse(collection["Width"]),
                Depth = int.Parse(collection["Depth"]),
                Weight = int.Parse(collection["Weight"]),
                IsOpened = bool.Parse(collection["IsOpened"]),
                Id = id
            };
            //save to database
            //display correct page. 
            new GiftServices().EditGift(updatedGift, id);
            return RedirectToAction("Index");
        }

        //get gift for delete. 
        [HttpGet]
        public ActionResult Delete(int id)
        {
            var gift = new GiftServices().GetGift(id);
            return View(gift);
        }

        //delete gift
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            // TODO: fix this
            new GiftServices().DeleteGift(id);
            return RedirectToAction("Index");
        }

        //get the gift to open
        [HttpGet]
        public ActionResult Open(int id)
        {
            var gift = GiftServices.GetGift(id);
            return View(gift);
        }

        //post for open gift
        [HttpPost]
        public ActionResult Open(int id, FormCollection collection)
        {
            GiftServices.OpenGift(id);
            return RedirectToAction("Index");
        }
    }
    
}