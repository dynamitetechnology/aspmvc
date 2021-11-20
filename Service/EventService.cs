using ASPMvc.Dal;
using ASPMvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ASPMvc.Service
{
    public class EventService
    {
        EventDal dal = new EventDal();

        public int insertEvent(Event events)
        {
            return dal.insertEvent(events);
        }

        public List<Event> getEventList()
        {
            return dal.getEventList();
        }

        public List<Event> getEventById(string id)
        {
            return dal.getEventById(id);
        }

        public int updateEvent(Event events)
        {
            return dal.updateEvent(events);
        }

        public int deleteEvent(string id)
        {
            return dal.deleteEvent(id);
        }
    }
}