using System;
using System.Collections.Generic;
using System.Data;

namespace Shsict.InternalWeb.Models
{
    public class MechanicalError
    {
        public MechanicalError() { }

        public MechanicalError(DataRow dr)
        {
            InitMechanicalError(dr);
        }

        private void InitMechanicalError(DataRow dr)
        {
            if (dr != null)
            {
                ID = dr["ID"].ToString();
                JobNo = dr["JobNo"].ToString();
                SENDMESSAGE = dr["SENDMESSAGE"].ToString();
                SENDTIME = DateTime.Parse(dr["SENDTIME"].ToString());
                ERRORTIME = dr["ERRORTIME"].ToString();
                ISSEND = dr["ISSEND"].ToString();
                MECHANICALNO = dr["MECHANICALNO"].ToString();
                FAULTSTATUS = dr["FAULTSTATUS"].ToString();


                if (!string.IsNullOrEmpty(dr["BEGINTIME"].ToString()))
                {
                    BEGINTIME = DateTime.Parse(dr["BEGINTIME"].ToString());
                }
                else
                {
                    BEGINTIME = null;
                }
                if (!string.IsNullOrEmpty(dr["FINISHTIME"].ToString()))
                {
                    FINISHTIME = DateTime.Parse(dr["FINISHTIME"].ToString());
                }
                else
                {
                    FINISHTIME = null;
                }
            }
            else
            {
                throw new Exception("Unable to init MechanicalError.");
            }
        }

        #region members and propertis

        public string ID { get; set; }

        public string JobNo { get; set; }

        public string SENDMESSAGE { get; set; }

        public DateTime SENDTIME { get; set; }

        public string ERRORTIME { get; set; }

        public string ISSEND { get; set; }

        public string MECHANICALNO { get; set; }

        public string SEARCHKEY { get; set; }

        public string FAULTSTATUS { get; set; }

        public DateTime? BEGINTIME { get; set; }

        public DateTime? FINISHTIME { get; set; }
        #endregion

        public static List<MechanicalError> GetMechanicalErrors()
        {
            DataTable dt = Shsict.DataAccess.SendMessage.GetSendMessages();
            List<MechanicalError> list = new List<MechanicalError>();

            if (dt != null)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    list.Add(new MechanicalError(dr));
                }
            }

            return list;
        }
        public static void UpdateMechanicalError(string id)
        {
            Shsict.DataAccess.SendMessage.UpdateSendMessages(id);    
        }

     
    }
}