using ASPMvc.Models;
using ASPMvc.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ASPMvc.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            EventService service = new EventService();
            List<Event> list = service.getEventList();
            return View(list);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult AddEvent(Event events)
        {
            EventService service = new EventService();
          int status =   service.insertEvent(events);

            return Redirect("/Home/Index");
        }

        public ActionResult viewinfo(string id)
        {
            EventService service = new EventService();
            List<Event> list = service.getEventById(id);
            return View(list);
        }

        public ActionResult edit(string id)
        {
            EventService service = new EventService();
            List<Event> list = service.getEventById(id);
            return View(list);
        }

        public ActionResult UpdateEvent(Event events)
        {
            EventService service = new EventService();
            int status = service.updateEvent(events);
            return Redirect("/Home/Index");
        }

        public ActionResult delete(string id)
        {
            EventService service = new EventService();
            int status = service.deleteEvent(id);

            return Redirect("/Home/Index");
        }
    }
}