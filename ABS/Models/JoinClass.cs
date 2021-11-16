using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ABS.Models
{
    public class JoinClass
    {
        public string Ref { get; set; }
        public DateTime ComplainDate { get; set; }
        public string ComplainType { get; set; }

        public string Complain { get; set; }

        public string Reply { get; set; }

        public string Ad_User { get; set; }

        public DateTime Ad_Date { get; set; }

        public DateTime ResponseDate { get; set; }
    }
}