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

        public ActionResult JazzTable()
        {
            IEnumerable<JazzEvent> jazzEvents = repository.GetAllJazzEvents();
            List<List<JazzTableView>> tableViews = new List<List<JazzTableView>>();

            List<JazzTableView> temp = new List<JazzTableView>();
            temp.Add(ToJazzTableView(jazzEvents.ElementAt(0)));
            for (int i = 1; i < jazzEvents.Count(); i++)
            {
                JazzEvent previous = jazzEvents.ElementAt(i - 1);
                JazzEvent current = jazzEvents.ElementAt(i);
                if (current.StartTime.Date == previous.StartTime.Date)
                {
                    temp.Add(ToJazzTableView(current));
                } else
                {
                    temp = temp.OrderBy(t => t.Location).ThenBy(t => t.StartTime).ToList();
                    tableViews.Add(temp);
                    temp = new List<JazzTableView>();
                    temp.Add(ToJazzTableView(current));
                }
            }

            tableViews.Add(temp);

            /*// Thursday
            IEnumerable<JazzEvent> thursday = repository.GetJazzEventsByDate(new DateTime(2019, 7, 25));

            List<JazzTableView> tempThursday = new List<JazzTableView>();

            foreach (JazzEvent jEvent in thursday)
            {
                tempThursday.Add(ToJazzTableView(jEvent));
            }

            // Friday
            IEnumerable<JazzEvent> friday = repository.GetJazzEventsByDate(new DateTime(2019, 7, 26));

            List<JazzTableView> tempFriday = new List<JazzTableView>();

            foreach (JazzEvent jEvent in friday)
            {
                tempFriday.Add(ToJazzTableView(jEvent));
            }

            // Saturday
            IEnumerable<JazzEvent> saturday = repository.GetJazzEventsByDate(new DateTime(2019, 7, 27));

            List<JazzTableView> tempSaturday = new List<JazzTableView>();

            foreach (JazzEvent jEvent in saturday)
            {
                tempSaturday.Add(ToJazzTableView(jEvent));
            }

            // Sunday
            IEnumerable<JazzEvent> sunday = repository.GetJazzEventsByDate(new DateTime(2019, 7, 28));

            List < JazzTableView > tempSunday = new List<JazzTableView>();

            foreach (JazzEvent jEvent in sunday)
            {
                tempSunday.Add(ToJazzTableView(jEvent));
            }

            JazzTables jazzTables = new JazzTables(tempThursday, tempFriday, tempSaturday, tempSunday); */

            return PartialView(tableViews);
        }

        public JazzTableView ToJazzTableView(JazzEvent JazzEvent)
        {
            JazzTableView jazzTableView = new JazzTableView();

            jazzTableView.Id = JazzEvent.EventId;

            jazzTableView.StartTime = JazzEvent.StartTime;

            jazzTableView.Time = string.Format("{0}:{1:00} - {2}:{3:00}", JazzEvent.StartTime.Hour, JazzEvent.StartTime.Minute, JazzEvent.EndTime.Hour, JazzEvent.EndTime.Minute);
            jazzTableView.Location = JazzEvent.JazzVenue.Name;
            jazzTableView.Band = JazzEvent.JazzArtist;

            if (JazzEvent.Price == 0)
            {
                jazzTableView.Price = "Free";
            }
            else
            {
                jazzTableView.Price = "€" + JazzEvent.Price + ".00";
            }

            return jazzTableView;
        }

        public ActionResult JazzSlideShow()
        {
            IEnumerable<JazzEvent> events = repository.GetAllJazzEvents();

            List<SlideShowView> SlideShowViews = new List<SlideShowView>();

            foreach (JazzEvent jEvent in events)
            {
                if (jEvent.PictureLocation != null)
                {
                    SlideShowView slideShowView = new SlideShowView();
                    slideShowView.BandName = jEvent.JazzArtist;
                    slideShowView.Description = jEvent.Description;
                    slideShowView.ImageLink = jEvent.PictureLocation;

                    SlideShowViews.Add(slideShowView);
                }
            }

            return PartialView(SlideShowViews);
        }
    }
}