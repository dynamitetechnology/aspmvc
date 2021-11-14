using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ASPMvc.Models
{
    public class Event
    {
        public  int id { get; set; }
        public string eventName { get; set; }
        public string startDate { get; set; }
        public string endDate { get; set; }
        public string description { get; set; }

    }
}