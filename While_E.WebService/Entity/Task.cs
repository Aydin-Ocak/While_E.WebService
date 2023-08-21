using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace While_E.WebService.Entity
{
    public class Task
    {
        public int taskId { get; set; }
        public string taskName { get; set; }
        public string taskDesc { get; set; }
        public bool taskComplete { get; set; }
        public int userID { get; set; }
    }
}