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
    }
}