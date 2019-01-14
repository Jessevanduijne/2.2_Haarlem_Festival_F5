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
        IEnumerable<Artist> Artist;
        ArtistView a;
        IList<ArtistView> Artistlist;
        Ticketview Tickets;
        
        
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult DanceTickets()
        {
            // get dance events
            DanceEvents = repo.GetAllDanceEvents();
            Tickets = Tickets.DomainToView(DanceEvents);
            return PartialView(Tickets);
        }
        public ActionResult Artists()
        {
            // get artists
            Artist = repo.GetAllArtists();
            Artistlist = a.DomainToView(Artist);
            return PartialView(Artistlist);
        }
    }
}