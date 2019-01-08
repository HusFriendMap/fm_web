using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Web;

namespace ManagerUser.ManagerUsers
{
    public class UserQuery : BaseQuery
    {
        public UserQuery()
        {
        }
        public UserQuery(HttpRequest request)
        {
            DateTimeFormatInfo dtfi = new DateTimeFormatInfo();
            PropertyInfo[] properties = this.GetType().GetProperties(BindingFlags.Public |
                BindingFlags.Instance | BindingFlags.DeclaredOnly);
            foreach (PropertyInfo pinfo in properties)
            {
                if (!string.IsNullOrEmpty(request[pinfo.Name]))
                {
                    var values = request[pinfo.Name];
                    switch (pinfo.PropertyType.FullName)
                    {
                        case "System.Int32":
                            if (!string.IsNullOrEmpty(values))
                            {
                                pinfo.SetValue(this, System.Convert.ToInt32(values), null);
                            }
                            break;
                        case "System.Nullable`1[[System.DateTime, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]]":
                        case "System.DateTime ?":
                        case "System.DateTime":
                            if (!string.IsNullOrEmpty(values))
                            {
                                dtfi.ShortDatePattern = "MM/dd/yyyy";
                                dtfi.DateSeparator = "/";
                                DateTime dtTemp = System.Convert.ToDateTime(values, dtfi);
                                if (dtTemp.Year < 1900 && dtTemp.Year > 2099)
                                    dtTemp = new DateTime(2012, 2, 30);
                                pinfo.SetValue(this, ((DateTime)dtTemp), null);
                            }
                            else
                            {
                                object dateNullValue = null;
                                pinfo.SetValue(this, dateNullValue, null);
                            }
                            break;
                        case "System.Collections.Generic.List`1[[System.String, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]]":
                            if (!string.IsNullOrEmpty(values))
                            {
                                List<string> lstValues = values.Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries).ToList();
                                pinfo.SetValue(this, (lstValues), null);
                            }
                            else
                                pinfo.SetValue(this, (new List<string>()), null);
                            break;
                        case "System.Collections.Generic.List`1[[System.Int32, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]]":
                            if (!string.IsNullOrEmpty(values))
                            {
                                List<int> lstValuesInt = pActionBase.GetDanhSachIDsQuaFormPost(values);
                                pinfo.SetValue(this, (lstValuesInt), null);
                            }
                            else
                                pinfo.SetValue(this, (new List<int>()), null);
                            break;
                        default:
                        case "System.String":
                            if (!string.IsNullOrEmpty(values))
                            {
                                pinfo.SetValue(this, (values).Trim(), null);
                            }
                            else
                            {
                                pinfo.SetValue(this, "", null);
                            }
                            break;
                    }
                }
            }
        }
    }
}