using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Haarlem_Festival.Repositories.Dance;
using Haarlem_Festival.Models.Domain_Models.Dance;
using Haarlem_Festival.Models.View_Models.Dance;

namespace Haarlem_Festival.Controllers
{
    public class DanceController : Controller
    {
        readonly IDanceRepository repo = new DanceRepository();
        IEnumerable<DanceEvent> DanceEvents;
        // IEnumerable<Artist> Artits;
        ArtistView Artistview;
        Ticketview Ticketview;
        
        // GET: Dance
        [HttpGet]
        public ActionResult Index()
        {
            //DanceEvents = repo.GetAllDanceEvents();
            //Ticketview = Ticketview.DomainToView(DanceEvents);
            return View();
        }
    }
}