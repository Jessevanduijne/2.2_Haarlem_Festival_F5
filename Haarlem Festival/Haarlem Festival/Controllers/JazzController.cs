using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Haarlem_Festival.Repositories.Jazz;
using Haarlem_Festival.Models.Domain_Models.Jazz;

namespace Haarlem_Festival.Controllers
{
    public class JazzController : Controller
    {
        JazzRepository repository = new JazzRepository();
        // GET: Jazz
        public ActionResult Index()
        {
            IEnumerable<JazzEvent> events = repository.GetAllJazzEvents();
            //IEnumerable<JazzEvent> events = repository.GetJazzEventsByDate(new DateTime(2019, 1, 1));

            return View(events);
        }
    }
}