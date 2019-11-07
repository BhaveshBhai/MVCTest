using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SafetracWebApp.Models
{
    public class UserModelView
    {
        public int Id { get; set; }
        public string First_Name { get; set; }
        public string Last_Name { get; set; }
        public string Email { get; set; }
        public DateTime? CreatedDate { get; set; }

        public List<GetAllUsers_Result> GetAllUsers()
        {
            List<GetAllUsers_Result> lstUser = new List<GetAllUsers_Result>();
            try
            {
                using (SafetracEntities db = new SafetracEntities())
                {
                  lstUser = db.GetAllUsers().ToList();
                    return lstUser;
                }
            }
            catch (Exception e)
            {
                return lstUser;
            }

        }

        public List<ListUsers_Result> LoadAllUsers(string Search, int StartPage, int Lenght,string Sort,string order)
        {
            List<ListUsers_Result> lstUser = new List<ListUsers_Result>();
            try
            {
                using (SafetracEntities db = new SafetracEntities())
                {
                    lstUser = db.ListUsers(Search, StartPage==0?1:StartPage, Lenght, Sort, order).ToList();
                    return lstUser;
                }
            }
            catch (Exception e)
            {
                return lstUser;
            }

        }

    }
}