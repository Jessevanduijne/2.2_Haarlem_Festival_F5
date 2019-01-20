using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Haarlem_Festival.Repositories.Jazz;
using Haarlem_Festival.Models.Domain_Models.Jazz;
using Haarlem_Festival.Models.View_Models.Jazz;

namespace Haarlem_Festival.Controllers
{
    public class JazzController : Controller
    {
        JazzRepository repository = new JazzRepository();
        // GET: Jazz
        public ActionResult Index()
        {
            GetAllJEventsInViewbag();

            MakeSlideshowList(repository.GetAllJazzEvents());



            return View();
        }

        public void GetAllJEventsInViewbag()
        {
            // Thursday
            IEnumerable<JazzEvent> thursday = repository.GetJazzEventsByDate(new DateTime(2019, 7, 26));

            ViewBag.JThursday = new List<JazzTableView>();

            foreach(JazzEvent jEvent in thursday)
            {
                ViewBag.JThursday.Add(ToJazzTableView(jEvent));
            }

            // Friday
            IEnumerable<JazzEvent> friday = repository.GetJazzEventsByDate(new DateTime(2019, 7, 27));

            ViewBag.JFriday = new List<JazzTableView>();

            foreach (JazzEvent jEvent in friday)
            {
                ViewBag.JFriday.Add(ToJazzTableView(jEvent));
            }

            // Saturday
            IEnumerable<JazzEvent> saturday = repository.GetJazzEventsByDate(new DateTime(2019, 7, 28));

            ViewBag.JSaturday = new List<JazzTableView>();

            foreach (JazzEvent jEvent in saturday)
            {
                ViewBag.JSaturday.Add(ToJazzTableView(jEvent));
            }

            // Sunday
            IEnumerable<JazzEvent> sunday = repository.GetJazzEventsByDate(new DateTime(2019, 7, 29));

            ViewBag.JSunday = new List<JazzTableView>();

            foreach (JazzEvent jEvent in sunday)
            {
                ViewBag.JSunday.Add(ToJazzTableView(jEvent));
            }
        }

        public JazzTableView ToJazzTableView(JazzEvent JazzEvent)
        {
            JazzTableView view = new JazzTableView();

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