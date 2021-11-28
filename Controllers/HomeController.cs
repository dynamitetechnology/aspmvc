using ASPMvc.Models;
using ASPMvc.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

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

        [HttpPost]
        public String AddEventApi(Event events)
        {
            Dictionary<string, string> jsonStatus = new Dictionary<string, string>();
            try
            {
                EventService service = new EventService();
                int status = service.insertEvent(events);
               

                if (status > 0)
                {
                    jsonStatus.Add("status", "200");
                    jsonStatus.Add("Message", "Success");
                    return (new JavaScriptSerializer()).Serialize(jsonStatus);
                }
                else
                {
                    jsonStatus.Add("status", "400");
                    jsonStatus.Add("Message", "Event Name Allready Exist");
                    return (new JavaScriptSerializer()).Serialize(jsonStatus);
                }
            }
            catch (Exception Ex)
            {
                jsonStatus.Add("status", "500");
                jsonStatus.Add("Message", Ex.Message);
                return (new JavaScriptSerializer()).Serialize(jsonStatus);
            }
        
        }


        [HttpPost]
        public String UpdateEventApi(Event events)
        {
            Dictionary<string, string> jsonStatus = new Dictionary<string, string>();
            try
            {
                EventService service = new EventService();
                int status = service.updateEvent(events);


                if (status > 0)
                {
                    jsonStatus.Add("status", "200");
                    jsonStatus.Add("Message", "Success");
                    return (new JavaScriptSerializer()).Serialize(jsonStatus);
                }
                else
                {
                    jsonStatus.Add("status", "400");
                    jsonStatus.Add("Message", "Event Name Allready Exist");
                    return (new JavaScriptSerializer()).Serialize(jsonStatus);
                }
            }
            catch (Exception Ex)
            {
                jsonStatus.Add("status", "500");
                jsonStatus.Add("Message", Ex.Message);
                return (new JavaScriptSerializer()).Serialize(jsonStatus);
            }
        }

        [HttpPost]
        public String DeleteEventApi(string  id)
        {
            Dictionary<string, string> jsonStatus = new Dictionary<string, string>();
            try
            {
                EventService service = new EventService();
                int status = service.deleteEvent(id);


                if (status > 0)
                {
                    jsonStatus.Add("status", "200");
                    jsonStatus.Add("Message", "Success");
                    return (new JavaScriptSerializer()).Serialize(jsonStatus);
                }
                else
                {
                    jsonStatus.Add("status", "400");
                    jsonStatus.Add("Message", "Event Name Allready Exist");
                    return (new JavaScriptSerializer()).Serialize(jsonStatus);
                }
            }
            catch (Exception Ex)
            {
                jsonStatus.Add("status", "500");
                jsonStatus.Add("Message", Ex.Message);
                return (new JavaScriptSerializer()).Serialize(jsonStatus);
            }
        }
    }
}