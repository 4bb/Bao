using Shsict.DataAccess;
using System;
using System.Collections.Generic;
using System.Data;

namespace Shsict.InternalWeb.Models
{
    /// <summary>
    /// 靠离泊情况
    /// </summary>
    public class LoginModel
    {
        public LoginModel() { }

        public LoginModel(DataRow dr)
        {
            InitLoginModel(dr);
        }

        private void InitLoginModel(DataRow dr)
        {
            if (dr != null)
            {
                SUR_USERACCOUNT = dr["SUR_USERACCOUNT"].ToString();
                SUR_PASSWORD = dr["SUR_PASSWORD"].ToString();
                SUR_DISPLAYNAME = dr["SUR_DISPLAYNAME"].ToString();
                SUR_DESCRIPTION = dr["SUR_DESCRIPTION"].ToString();
                if (!string.IsNullOrEmpty(dr["SUR_CREATETIME"].ToString()))
                {
                    SUR_CREATETIME = DateTime.Parse(dr["SUR_CREATETIME"].ToString());
                }
                else
                {
                    SUR_CREATETIME = null;
                }
                if (!string.IsNullOrEmpty(dr["SUR_UPDATETIME"].ToString()))
                {
                    SUR_UPDATETIME = DateTime.Parse(dr["SUR_UPDATETIME"].ToString());
                }
                else
                {
                    SUR_UPDATETIME = null;
                }
                SUR_GROUP = dr["SUR_GROUP"].ToString();
                SUR_STATUS = dr["SUR_STATUS"].ToString();
                SUR_ERRORCOUNT = dr["SUR_ERRORCOUNT"].ToString();
                SUR_ISLOOKED = dr["SUR_ISLOOKED"].ToString();
            }
            else
            {
                throw new Exception("Unable to init User.");
            }
        }

        #region members and propertis
        public string SUR_USERACCOUNT { get; set; }

        public string SUR_PASSWORD { get; set; }

        public string SUR_DISPLAYNAME { get; set; }

        public string SUR_DESCRIPTION { get; set; }

        public DateTime? SUR_CREATETIME { get; set; }

        public DateTime? SUR_UPDATETIME { get; set; }

        public string SUR_GROUP { get; set; }

        public string SUR_STATUS { get; set; }

        public string SUR_ERRORCOUNT { get; set; }

        public string SUR_ISLOOKED { get; set; }
        #endregion


        public static List<LoginModel> GetLoginModels()
        {
            DataTable dt = Shsict.DataAccess.InternalUser.GetInternalUsers();
            List<LoginModel> list = new List<LoginModel>();

            if (dt != null)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    list.Add(new LoginModel(dr));
                }
            }

            return list;
        }
        public static List<LoginModel> GetLoginModelByUserName(string userName)
        {
            DataTable dt = Shsict.DataAccess.InternalUser.GetInternalUserByUserName(userName);
            List<LoginModel> list = new List<LoginModel>();

            if (dt != null)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    list.Add(new LoginModel(dr));
                }
            }

            return list;
        }



    }
    public class UserResource
    {
        public UserResource() { }

        public UserResource(DataRow dr)
        {
            InitUserResource(dr);
        }

        private void InitUserResource(DataRow dr)
        {
            if (dr != null)
            {
                SUR_USERACCOUNT = dr["SUR_USERACCOUNT"].ToString();
                SUR_RESOURCECODE = dr["SUR_RESOURCECODE"].ToString();
            }
            else
            {
                throw new Exception("Unable to init User.");
            }
        }

        #region members and propertis

        public string SUR_USERACCOUNT { get; set; }

        public string SUR_RESOURCECODE { get; set; }

        #endregion

        public static List<UserResource> GetUserResourceByUserName(string userName)
        {
            DataTable dt = Shsict.DataAccess.InternalUser.GetUserResourceByUserName(userName);
            List<UserResource> list = new List<UserResource>();

            if (dt != null)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    list.Add(new UserResource(dr));
                }
            }

            return list;
        }

    }
}