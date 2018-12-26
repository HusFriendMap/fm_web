using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace ManagerUser
{
    public class BaseQuery
    {
        public int ID { get; set; }
        public string Keyword { get; set; }
        public bool isToDay { get; set; }
        public bool isYesterday { get; set; }
        public bool isWeek { get; set; }
        /// <summary>
        /// Search
        /// </summary>
        public List<string> SearchIn { get; set; }
        /// <summary>
        /// Đến ngày
        /// </summary>
        public DateTime? SearchDenNgay { get; set; }
        /// <summary>
        /// Từ ngày		/// </summary>
        public DateTime? SearchTuNgay { get; set; }
        public List<int> lstIDget { get; set; }
        public bool isGetBylistID { get; set; }
        public int pageSize = 0;
        public int page = 1;
        public int start { get; set; }
        public string FieldSort = "ID";
        public bool FieldOption = false;
        public List<GridSort> GridSort { get; set; }
        public int ItemID { get; set; }
        public int Author { get; set; }
        public int _ModerationStatus = -1;
        public bool isNgayHetHan { get; set; }
        
        public BaseQuery()
        {
            GridSort = new List<GridSort>();
            _ModerationStatus = -1;
            lstIDget = new List<int>();
        }
        
        public BaseQuery(HttpRequest request)
        {
            if (!string.IsNullOrEmpty(request["_ModerationStatus"]))
            {
                _ModerationStatus = Convert.ToInt32(request["_ModerationStatus"]);
            }
            else
            {
                _ModerationStatus = -1;
            }
            DateTimeFormatInfo dtfiParser;
            dtfiParser = new DateTimeFormatInfo();
            dtfiParser.ShortDatePattern = "dd/MM/yyyy";
            dtfiParser.DateSeparator = "/";
            if (!string.IsNullOrEmpty(request["SearchDenNgay"]))
                SearchDenNgay = Convert.ToDateTime(request["SearchDenNgay"], dtfiParser);
            else
                SearchDenNgay = null;
            if (!string.IsNullOrEmpty(request["SearchTuNgay"]))
                SearchTuNgay = Convert.ToDateTime(request["SearchTuNgay"], dtfiParser);
            else
                SearchTuNgay = null;
            if (!string.IsNullOrEmpty(request["ItemID"]))
                ItemID = Convert.ToInt32(request["ItemID"]);
            else
                ItemID = -1;
            // timkiem theo ngay thang
            if (!string.IsNullOrEmpty(request["date"]))
            {
                if (request["date"].ToString().Equals("1"))
                {
                    isToDay = true;
                }
                else if (request["date"].ToString().Equals("2"))
                {
                    isYesterday = true;
                }
                else if (request["date"].ToString().Equals("3"))
                {
                    isWeek = true;
                }
            }
            /// tim kiem theo tu khoa:  keyword
            if (!string.IsNullOrEmpty(request["keyword"]))
            {
                Keyword = request["keyword"].Trim();
                Keyword = Regex.Replace(Keyword, @"\s+", " ");//Xóa khoảng trắng
            }
            else
                Keyword = string.Empty;

            string tempSearchIn;
            if (!string.IsNullOrEmpty(request["SearchInAdvance"]))
                tempSearchIn = request["SearchInAdvance"];
            else if (!string.IsNullOrEmpty(request["SearchInSimple"]))
                tempSearchIn = request["SearchInSimple"];
            else
                tempSearchIn = "Title";

            if (!string.IsNullOrEmpty(tempSearchIn))
            {
                if (tempSearchIn.Contains(','))
                    SearchIn = tempSearchIn.Split(',').ToList();
                else
                    SearchIn = new List<string>() { tempSearchIn };
            }
            else
                SearchIn = new List<string>();
            if (!string.IsNullOrEmpty(request["Author"]))
                Author = Convert.ToInt32(request["Author"]);
            else Author = 0;
            lstIDget = new List<int>();
            if (!string.IsNullOrEmpty(request["lstID"]))
            {
                string lstID = request["lstID"].Trim();
                List<string> lst = new List<string>();
                if (lstID.Contains(','))
                    lst = lstID.Split(',').ToList();
                else
                    lst.Add(lstID);
                for (int i = 0; i < lst.Count; i++)
                {
                    if (!string.IsNullOrEmpty(lst[i]))
                        lstIDget.Add(Convert.ToInt32(lst[i]));
                }
                isGetBylistID = true;
            }
            if (!string.IsNullOrEmpty(request["isGetBylistID"]))
                isGetBylistID = Convert.ToBoolean(request["isGetBylistID"]);
            GridSort = new List<GridSort>();
            FieldSort = "ID";
            FieldOption = false;

            #region thông tin boostrap
            if (!string.IsNullOrEmpty(request["draw"]))
            {
                draw = Convert.ToInt32(request["draw"]);
                KendoUIGrid = false;
                if (!string.IsNullOrEmpty(request["length"]))
                    pageSize = Convert.ToInt32(request["length"]);
                if (!string.IsNullOrEmpty(request["start"]))
                    start = Convert.ToInt32(request["start"]);
                if (start > 0 && pageSize > 0)
                    page = start / pageSize + 1;
                FieldOption = request["order[0][dir]"] == "desc" ? false : true;
                string indexCol = request["order[0][column]"];
                if (indexCol != null && indexCol.Length > 0)
                {
                    FieldSort = request[string.Format("columns[{0}][name]", indexCol)];
                    if (FieldSort == null || FieldSort.Length == 0)
                        FieldSort = request[string.Format("columns[{0}][data]", indexCol)];
                }
                else
                {
                    if (!string.IsNullOrEmpty(request["fieldOrder"]))
                    {
                        FieldSort = request["fieldOrder"];
                        FieldOption = request["ascending"] == "desc" ? false : true;

                    }
                    else if (!string.IsNullOrEmpty(request["FieldSort"]))
                    {
                        FieldSort = request["FieldSort"];
                        FieldOption = (request["FieldOption"] == "false" || request["ascending"] == "desc") ? false : true;
                    }
                    else if (GridSort.Count <= 0)
                    {
                        FieldSort = "ID";
                        FieldOption = false;
                    }

                }
                GridSort.Add(new GridSort() { field = FieldSort, dir = FieldOption });
            }
            #endregion
            if (!string.IsNullOrEmpty(request["fieldOrder"]))
            {
                FieldSort = request["fieldOrder"];
                FieldOption = (request["FieldOption"] == "false" || request["ascending"] == "desc") ? false : true;
            }
            else
            if (!string.IsNullOrEmpty(request["FieldSort"]) && !string.IsNullOrEmpty(request["ascending"]))
            {
                FieldSort = request["FieldSort"];
                FieldOption = (request["FieldOption"] == "false" || request["ascending"] == "desc") ? false : true;
            }
            #region Sort Grid Thong Ke
            if (!string.IsNullOrEmpty(request["FieldSort"]))
            {
                GridSort.Add(new GridSort() { field = request["FieldSort"], dir = ((!string.IsNullOrEmpty(request["FieldOption"]) && request["FieldOption"] == "true") ? true : false) });
            }
            if (!string.IsNullOrEmpty(request["GridSort[0][_field]"]) && !string.IsNullOrEmpty(request["GridSort[0][dir]"]))
            {
                GridSort.Add(new GridSort() { field = request["GridSort[0][_field]"], dir = (request["GridSort[0][dir]"] == "asc" ? true : false) });
            }
            #endregion
        }
        public int draw { get; set; }
        public bool KendoUIGrid { get; set; }


    }

    [Serializable]
    public struct GridSort
    {
        public string field { get; set; }
        public bool dir { get; set; }
    }
}