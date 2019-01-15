using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Haarlem_Festival.Models.Database_Connection;
using Haarlem_Festival.Models.Domain_Models.Historic;
using Haarlem_Festival.Repositories.Historic;

namespace Haarlem_Festival.Controllers
{
    public class HistoricController : Controller
    {
        private HFContext db = new HFContext();
        private IHistoricRepository historicRepository = new HistoricRepository();

        // GET: Historic
        public ActionResult Index()
        {
            // IEnumerable<HistoricEvent> historicEvents = historicRepository.GetAllTours();
            return View(db.Events.OfType<HistoricEvent>().ToList().OrderBy(x => x.EventId));
        }

        // GET: Historic/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HistoricEvent historicEvent = (HistoricEvent)db.Events.Find(id);
            if (historicEvent == null)
            {
                return HttpNotFound();
            }
            return View(historicEvent);
        }

        // GET: Historic/Create
        public ActionResult Create()
        {
            ViewBag.GuideID = new SelectList(db.Guides, "GuideID", "Name");
            return View();
        }

        // POST: Historic/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "EventId,EventName,StartTime,EndTime,MaxTickets,CurrentTickets,GuideID")] HistoricEvent historicEvent)
        {
            if (ModelState.IsValid)
            {
                db.Events.Add(historicEvent);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.GuideID = new SelectList(db.Guides, "GuideID", "Name", historicEvent.GuideID);
            return View(historicEvent);
        }

        // GET: Historic/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HistoricEvent historicEvent = (HistoricEvent)db.Events.Find(id);
            if (historicEvent == null)
            {
                return HttpNotFound();
            }
            ViewBag.GuideID = new SelectList(db.Guides, "GuideID", "Name", historicEvent.GuideID);
            return View(historicEvent);
        }

        // POST: Historic/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "EventId,EventName,StartTime,EndTime,MaxTickets,CurrentTickets,GuideID")] HistoricEvent historicEvent)
        {
            if (ModelState.IsValid)
            {
                db.Entry(historicEvent).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.GuideID = new SelectList(db.Guides, "GuideID", "Name", historicEvent.GuideID);
            return View(historicEvent);
        }

        // GET: Historic/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HistoricEvent historicEvent = (HistoricEvent)db.Events.Find(id);
            if (historicEvent == null)
            {
                return HttpNotFound();
            }
            return View(historicEvent);
        }

        // POST: Historic/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            HistoricEvent historicEvent = (HistoricEvent)db.Events.Find(id);
            db.Events.Remove(historicEvent);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
