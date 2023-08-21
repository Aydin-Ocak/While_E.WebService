using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using While_E.WebService.Class;
using While_E.WebService.Entity;

namespace While_E.WebService
{
    /// <summary>
    /// Summary description for Service
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class Service : System.Web.Services.WebService
    {
        [WebMethod]
        public List<User> Get_User()
        {
            return DBLayer.GetUserList();
        }
        [WebMethod]
        public void Add_User(string name, string role)
        {
            DBLayer.AddUser(name, role);
        }
        [WebMethod]
        public void Del_User(int ID)
        {
            DBLayer.DelUser(ID);
        }
        [WebMethod]
        public void Update_User(int ID, string name, string role)
        {
            DBLayer.UpdateUser(ID, name, role);
        }
        [WebMethod]
        public List<Task> Get_Task()
        {
            return DBLayer.getTaskList();
        }
        [WebMethod]
        public void Add_Task(string name, string desc, bool comp, int userID)
        {
            DBLayer.AddTask(name, desc, comp, userID);
        }
        [WebMethod]
        public void Del_Task(int ID)
        {
            DBLayer.DellTask(ID);
        }
        [WebMethod]
        public void Update_Task(int ID, bool comp)
        {
            DBLayer.UpdateTask(ID, comp);
        }
        [WebMethod]
        public List<User> Get_Selected_User(string name)
        {
            return DBLayer.getSelectedUser(name);
        }
        [WebMethod]
        public List<Task> Get_Selected_Task(int ID)
        {
            return DBLayer.getSelectedTask(ID);
        }
        [WebMethod]
        public List<User> Get_UserName(string name)
        {
            return DBLayer.Get_UserName(name);
        }

    }
}
