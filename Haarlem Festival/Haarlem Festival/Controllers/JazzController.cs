using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Haarlem_Festival.Repositories.Jazz;
using Haarlem_Festival.Models.Domain_Models.Jazz;
using Haarlem_Festival.Models.View_Models.Jazz;
using Haarlem_Festival.Repositories.Events;
using Haarlem_Festival.Models.Domain_Models.General;

namespace Haarlem_Festival.Controllers
{
    public class JazzController : Controller
    {
        JazzRepository repository = new JazzRepository();
        EventRepository eventRepo = new EventRepository();

        // GET: Jazz
        public ActionResult Index()
        {
            GetAllJEventsInViewbag();

            MakeSlideshowList(repository.GetAllJazzEvents());

            return View();
        }

        [HttpPost] 
        public ActionResult JazzOrder()
        {
            int EventId = int.Parse(Request.Form["EventId"]);
            int Amount = int.Parse(Request.Form["TicketAmount"]);

            JazzEvent e = repository.GetJazzEvent(EventId);

            List<Ticket> tickets = new List<Ticket>();
            Ticket ticket = new Ticket();

            ticket.Amount = Amount;
            ticket.EventId = e.EventId;
            ticket.Event = eventRepo.GetEvent(e.EventId);
            ticket.Price = (float)e.Price * Amount;
            ticket.SpecialRequest = null;

            if (ticket.Amount > (ticket.Event.MaxTickets - ticket.Event.CurrentTickets))
            {
                return RedirectToAction("NoTickets", "Jazz");
            }
            else
            {
                // Create session if it doesn't exist or add ticket to existing session
                if (Session["currentTickets"] == null)
                {
                    tickets.Add(ticket);
                    Session["CurrentTickets"] = tickets;
                }
                else
                {
                    List<Ticket> sessionTickets = (List<Ticket>)Session["currentTickets"];
                    sessionTickets.Add(ticket);
                }
                return RedirectToAction("Index", "Ticket");
            }
        }

        public ActionResult NoTickets()
        {
            return View();
        }

        public void GetAllJEventsInViewbag()
        {
            // Thursday
            IEnumerable<JazzEvent> thursday = repository.GetJazzEventsByDate(new DateTime(2019, 7, 25));

            ViewBag.JThursday = new List<JazzTableView>();

            foreach(JazzEvent jEvent in thursday)
            {
                ViewBag.JThursday.Add(ToJazzTableView(jEvent));
            }

            // Friday
            IEnumerable<JazzEvent> friday = repository.GetJazzEventsByDate(new DateTime(2019, 7, 26));

            ViewBag.JFriday = new List<JazzTableView>();

            foreach (JazzEvent jEvent in friday)
            {
                ViewBag.JFriday.Add(ToJazzTableView(jEvent));
            }

            // Saturday
            IEnumerable<JazzEvent> saturday = repository.GetJazzEventsByDate(new DateTime(2019, 7, 27));

            ViewBag.JSaturday = new List<JazzTableView>();

            foreach (JazzEvent jEvent in saturday)
            {
                ViewBag.JSaturday.Add(ToJazzTableView(jEvent));
            }

            // Sunday
            IEnumerable<JazzEvent> sunday = repository.GetJazzEventsByDate(new DateTime(2019, 7, 28));

            ViewBag.JSunday = new List<JazzTableView>();

            foreach (JazzEvent jEvent in sunday)
            {
                ViewBag.JSunday.Add(ToJazzTableView(jEvent));
            }
        }

        public JazzTableView ToJazzTableView(JazzEvent JazzEvent)
        {
            JazzTableView view = new JazzTableView();

            view.Id = JazzEvent.EventId;
            view.Time = string.Format("{0}:{1:00} - {2}:{3:00}", JazzEvent.StartTime.Hour, JazzEvent.StartTime.Minute, JazzEvent.EndTime.Hour, JazzEvent.EndTime.Minute);
            view.Location = JazzEvent.JazzVenue.Name;
            view.Band = JazzEvent.JazzArtist;

            if (JazzEvent.Price == 0)
            {
                view.Price = "Free";
            }
            else
            {
                view.Price = "€" + JazzEvent.Price + ".00";
            }

            return view;
        }

        public void MakeSlideshowList(IEnumerable<JazzEvent> events)
        {
            ViewBag.SlideShowViews = null;
            ViewBag.SlideShowViews = new List<SlideShowView>();

            foreach (JazzEvent jEvent in events)
            {
                if (jEvent.PictureLocation != null)
                {
                    SlideShowView slideShowView = new SlideShowView();
                    slideShowView.BandName = jEvent.JazzArtist;
                    slideShowView.Description = jEvent.Description;
                    slideShowView.ImageLink = jEvent.PictureLocation;

                    ViewBag.SlideShowViews.Add(slideShowView);
                }
            }
        }
    }
}