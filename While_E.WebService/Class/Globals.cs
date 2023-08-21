using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace While_E.WebService.Class
{
    public class Globals
    {
        public static string DBConnection
        {
            get
            {
                return ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            }
        }
    }
}