using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using While_E.WebService.Entity;

namespace While_E.WebService.Class
{

    public class DBLayer
    {
        public static List<User> GetUserList()
        {
            List<User> userList = new List<User>();
            using (SqlConnection con = new SqlConnection(Globals.DBConnection))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand(SqlConstants.sp_GET_USER, con))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.Clear();

                    SqlDataAdapter da = new SqlDataAdapter();
                    da.SelectCommand = cmd;
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    for(int i =0; i < dt.Rows.Count; i++)
                    {
                        User user = new User();
                        user.userID = (int)dt.Rows[i]["User_ID"];
                        user.userName = dt.Rows[i]["User_Name"].ToString();
                        user.userRole = dt.Rows[i]["User_Role"].ToString();
                        userList.Add(user);
                    }
                    return userList;
                        
                }
            }
        }
        public static List<Task> getTaskList()
        {
            List<Task> taskList = new List<Task>();
            using (SqlConnection con = new SqlConnection(Globals.DBConnection))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand(SqlConstants.sp_GET_TASK, con))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.Clear();

                    SqlDataAdapter da = new SqlDataAdapter();
                    da.SelectCommand = cmd;
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        Task task = new Task();
                        task.taskId = (int)dt.Rows[i]["Task_ID"];
                        task.taskName = dt.Rows[i]["Task_Name"].ToString();
                        task.taskDesc = dt.Rows[i]["Task_Desc"].ToString();
                        task.taskComplete = (bool)dt.Rows[i]["Task_Complete"];
                        task.userID = (int)dt.Rows[i]["User_ID"];
                        taskList.Add(task);
                    }
                    return taskList;

                }
            }
        }

            public static void AddUser(string name, string role)
        {
            using (SqlConnection con = new SqlConnection(Globals.DBConnection))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand(SqlConstants.sp_ADD_USER, con))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.Clear();

                    cmd.Parameters.AddWithValue("@NAME", name);
                    cmd.Parameters.AddWithValue("@ROLE", role);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public static void DelUser(int ID)
        {
            using (SqlConnection con = new SqlConnection(Globals.DBConnection))
            {
                using(SqlCommand cmd = new SqlCommand(SqlConstants.sp_DEL_USER, con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Clear();

                    cmd.Parameters.AddWithValue("@ID", ID);

                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }
        }

       public static void UpdateUser(int ID, string name, string role)
       {
            using(SqlConnection con = new SqlConnection(Globals.DBConnection))
            {
                using(SqlCommand cmd = new SqlCommand (SqlConstants.sp_UPDATE_USER, con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Clear();

                    cmd.Parameters.AddWithValue("@ID", ID);
                    cmd.Parameters.AddWithValue("@NAME", name);
                    cmd.Parameters.AddWithValue("@ROLE", role);

                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                        
                }
            }
       }
        public static void AddTask(string name, string desc, bool comp, int userID)
        {
            using (SqlConnection con = new SqlConnection(Globals.DBConnection))
            {
                using (SqlCommand cmd = new SqlCommand(SqlConstants.sp_ADD_TASK, con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Clear();

                    cmd.Parameters.AddWithValue("@NAME", name);
                    cmd.Parameters.AddWithValue("@DESC", desc);
                    cmd.Parameters.AddWithValue("@COMP", comp);
                    cmd.Parameters.AddWithValue("@USER_ID", userID);

                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }

        }

        public static void DellTask(int ID)
        {
            using (SqlConnection con = new SqlConnection(Globals.DBConnection))
            {
                using (SqlCommand cmd = new SqlCommand(SqlConstants.sp_DEL_TASK, con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Clear();

                    cmd.Parameters.AddWithValue("ID", ID);

                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }
        }
        public static void UpdateTask(int ID, bool comp)
        {
            using (SqlConnection con = new SqlConnection(Globals.DBConnection))
            {
                using (SqlCommand cmd = new SqlCommand(SqlConstants.sp_UPDATE_TASK, con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Clear();

                    cmd.Parameters.AddWithValue("ID", ID);
                    cmd.Parameters.AddWithValue("COMP", comp);

                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }
        }
        public static List<User> getSelectedUser(string name)
        {
            List<User> selectedUser = new List<User>();
            using (SqlConnection con = new SqlConnection(Globals.DBConnection))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand(SqlConstants.sp_GET_SELECTED_USER, con))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.Clear();

                    cmd.Parameters.AddWithValue("@NAME", name);

                    SqlDataAdapter da = new SqlDataAdapter();
                    da.SelectCommand = cmd;
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        User user = new User();
                        user.userID = (int)dt.Rows[i]["User_ID"];
                        user.userName = dt.Rows[i]["User_Name"].ToString();
                        user.userRole = dt.Rows[i]["User_Role"].ToString();
                        selectedUser.Add(user);
                    }
                    return selectedUser;

                }
            }
        }
        public static List<Task> getSelectedTask(int ID)
        {
            List<Task> selectedTask = new List<Task>();
            using (SqlConnection con = new SqlConnection(Globals.DBConnection))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand(SqlConstants.sp_GET_SELECTED_TASK, con))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.Clear();

                    cmd.Parameters.AddWithValue("@ID", ID);

                    SqlDataAdapter da = new SqlDataAdapter();
                    da.SelectCommand = cmd;
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        Task task = new Task();
                        task.taskId = (int)dt.Rows[i]["Task_ID"];
                        task.taskName = dt.Rows[i]["Task_Name"].ToString();
                        task.taskDesc = dt.Rows[i]["Task_Desc"].ToString();
                        task.taskComplete = (bool)dt.Rows[i]["Task_Complete"];
                        task.userID = (int)dt.Rows[i]["User_ID"];
                        selectedTask.Add(task);
                    }
                    return selectedTask;

                }
            }
        }
        public static List<User> Get_UserName(string name)
        {
            List<User> UserName = new List<User>();
            using(SqlConnection con = new SqlConnection(Globals.DBConnection))
            {
                using(SqlCommand cmd = new SqlCommand(SqlConstants.sp_GET_UserName, con))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.Clear();

                    cmd.Parameters.AddWithValue("@NAME", name);

                    SqlDataAdapter da = new SqlDataAdapter();
                    da.SelectCommand = cmd;
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        User user = new User();
                        user.userID = (int)dt.Rows[i]["User_ID"];
                        UserName.Add(user);
                    }
                    return UserName;
                }
            }
        }

    }
    
}