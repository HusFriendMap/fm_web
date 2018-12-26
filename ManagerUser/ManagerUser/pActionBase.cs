using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;

namespace ManagerUser
{
    public class pActionBase : System.Web.UI.Page, IHttpHandler
    {
        public string DoAction { get; set; }
        public string _id { get; set; }
        public List<int> LtsID { get; set; }
        public DateTime? denngay { get; set; }
        public DateTime? tungay { get; set; }
#pragma warning disable CS0114 // Member hides inherited member; missing override keyword
        public virtual void ProcessRequest(HttpContext context)
#pragma warning restore CS0114 // Member hides inherited member; missing override keyword
        {
            LtsID = new List<int>();
            #region Get tham số
            //DoAction
            if (!string.IsNullOrEmpty(context.Request["do"]))
                DoAction = context.Request["do"];
            if (!string.IsNullOrEmpty(context.Request["_id"]))
                _id = context.Request["_id"];
            if (!string.IsNullOrEmpty(context.Request["LtsID"]))
                LtsID = GetDanhSachIDsQuaFormPost(context.Request["LtsID"]);
        #endregion

        DateTimeFormatInfo dtfiParser;
            denngay = new DateTime?();
            tungay = new DateTime?();
            dtfiParser = new DateTimeFormatInfo();
            dtfiParser.ShortDatePattern = "dd/MM/yyyy";
            dtfiParser.DateSeparator = "/";
            if (!string.IsNullOrEmpty(Context.Request["SearchDenNgay"]))
                denngay = Convert.ToDateTime(Context.Request["SearchDenNgay"], dtfiParser);
            if (!string.IsNullOrEmpty(Context.Request["SearchTuNgay"]))
                tungay = Convert.ToDateTime(Context.Request["SearchTuNgay"], dtfiParser);
        }

        public static List<int> GetDanhSachIDsQuaFormPost(string arrID)
        {
            List<int> dsID = new List<int>();
            if (!string.IsNullOrEmpty(arrID))
            {
                string[] tempIDs = arrID.Split(',');
                foreach (string idConvert in tempIDs)
                {
                    if (!String.IsNullOrEmpty(idConvert))
                    {
                        int intvalue = Convert.ToInt32(idConvert);
                        if (intvalue != 0)
                            dsID.Add(Convert.ToInt32(idConvert));
                    }
                }
            }
            return dsID;
        }
    }
}