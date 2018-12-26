using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;

namespace ManagerUser
{
    public class BaseEntity
    {

        public void UpdateObject(HttpRequest request)
        {
            var properties = this.GetType().GetProperties();
            //Các trường hợp xử lý đặc biệt
            List<string> ltsRemove = new List<string>(){
                "ListFileAttach",
                "ListFileAttachAdd",
                "ListFileRemove",
                "hdfUrlImages",
                "srcImageNews",
                "srcAnhDaiDien",
                "srcAnhSuKien",
                "srcEventImages",
                "_ModerationStatus",
                "srcTC_Image",
                "srcImagesBook",
                "srcBook_AnhDaiDien",
                "Modified",
                "Created",
                "Editor",
                "Author",
                "ID"
            };
            DateTimeFormatInfo dtfi = new DateTimeFormatInfo();

            string values;

            foreach (System.Reflection.PropertyInfo pinfo in properties.Where(p => !ltsRemove.Contains(p.Name)).ToList())
            {
                if (request[pinfo.Name] != null) //Chỉ xét các tham số được post đi.
                {
                    values = request[pinfo.Name];
                    try
                    {
                        Type objType = pinfo.GetType();
                        //Check các kiểu dữ liệu gán vào object
                        switch (pinfo.PropertyType.FullName)
                        {
                            #region MyRegion
                            //case "MongoDB.Bson.ObjectId":
                            //    {
                            //        if (!string.IsNullOrEmpty(values))
                            //            pinfo.SetValue(this, MongoDB.Bson.ObjectId.Parse(values), null);
                            //        break;
                            //    }
                            case "System.Boolean":
                                {
                                    if (!string.IsNullOrEmpty(values))
                                    {
                                        if (values == "on")
                                            pinfo.SetValue(this, true, null);
                                        else
                                            pinfo.SetValue(this, Convert.ToBoolean(values), null);
                                    }
                                    else
                                        pinfo.SetValue(this, false, null);
                                    break;
                                }
                            case "System.Double":
                                if (!string.IsNullOrEmpty(values))
                                    pinfo.SetValue(this, Convert.ToDouble(values), null);
                                break;
                            case "System.Int32":
                                if (!string.IsNullOrEmpty(values))
                                    pinfo.SetValue(this, Convert.ToInt32(values), null);
                                break;
                            case "System.Nullable`1[[System.DateTime, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]]"://"System.Nullable`1[[System.DateTime, mscorlib, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]]":
                            case "System.DateTime ?":
                            case "System.DateTime":
                                if (!string.IsNullOrEmpty(values))
                                {
                                    //Định dạng ngày tháng
                                    dtfi.ShortDatePattern = "dd/MM/yyyy";
                                    dtfi.DateSeparator = "/";
                                    string temp = pinfo.Name;
                                    //Lấy giá trị request
                                    //Lấy kiểu dữ liệu
                                    DateTime dtTemp = DateTime.Now;
                                    if (DateTime.TryParse(values, dtfi, DateTimeStyles.None, out dtTemp))
                                    {
                                        DateTime dtTemp2 = Convert.ToDateTime(values, dtfi);
                                        if (dtTemp2.Year < 1900 && dtTemp2.Year > 2099)
                                            dtTemp2 = new DateTime(2012, 2, 30);
                                        pinfo.SetValue(this, ((DateTime)dtTemp2), null);
                                    }
                                    else
                                    {
                                        pinfo.SetValue(this, null, null);
                                    }
                                }
                                else
                                {
                                    //;\Convert.ChangeType(value, propertyInfo.PropertyType),
                                    pinfo.SetValue(this, null, null);
                                }
                                break;
                            default:
                            case "System.String":
                                if (!string.IsNullOrEmpty(values))
                                {
                                    pinfo.SetValue(this, ((string)values).Trim(), null);
                                }
                                else
                                {
                                    pinfo.SetValue(this, "", null);
                                }
                                break;
                                #endregion
                        }
                    }
                    catch (Exception ex)
                    {
                        //throw new UpdateException(string.Format("Lỗi tại trường <----{0}--->, value:---{1}---", pinfo.Name, values.Trim()));
                    }
                }

            }
        }
    }
}