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
            IEnumerable<JazzEvent> events = repository.GetAllJazzEvents();

            List<JazzTableView> jazzEvents = new List<JazzTableView>();

            foreach (JazzEvent jEvent in events)
            {
                jazzEvents.Add(ToJazzTableView(jEvent));
            }

            MakeSlideshowList(events);

            return View(jazzEvents);
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

                    List<SlideShowView> temp = ViewBag.SlideShowViews;
                    if (!(temp.Contains(slideShowView)))
                    {
                        ViewBag.SlideShowViews.Add(slideShowView);
                    }
                }
            }
        }
    }
}