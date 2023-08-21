using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace While_E.WebService.Class
{
    public class SqlConstants
    {
        public static readonly string sp_GET_USER = @"sp_GET_USER";
        public static readonly string sp_ADD_USER = @"sp_ADD_USER";
        public static readonly string sp_DEL_USER = @"sp_DEL_USER";
        public static readonly string sp_UPDATE_USER = @"sp_UPDATE_USER";
        public static readonly string sp_GET_TASK = @"sp_GET_TASKS";
        public static readonly string sp_ADD_TASK = @"sp_ADD_TASK";
        public static readonly string sp_DEL_TASK = @"sp_DEL_TASK";
        public static readonly string sp_UPDATE_TASK = @"sp_UPDATE_TASK";
        public static readonly string sp_GET_SELECTED_USER = @"sp_GET_SELECTED_USER";
        public static readonly string sp_GET_SELECTED_TASK = @"sp_GET_SELECTED_TASK";
        public static readonly string sp_GET_UserName = @"sp_GET_USERNAME";
    }
}