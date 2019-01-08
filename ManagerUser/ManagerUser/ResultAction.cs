using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ManagerUser
{
    public class ResultAction
    {
        public ActionState State { set; get; }
        public string Message { get; set; }
        public int TotalCount { set; get; }
        public int SucceedCount { set; get; }
        public List<int> Ids { set; get; }
        private object odata;
        public object OData { get { return odata; } set { odata = value; IsQuery = true; } }
        public bool IsQuery { get; set; }
        public int ID { get; set; }
        public bool Erros
        {
            get
            {
                if (State == ActionState.Succeed)
                    return false;
                else return true;
            }
        }
        public ResultAction()
        {
            Ids = new List<int>();
            State = ActionState.Succeed;
        }
        public ResultAction(ActionState _actionState, string _Message)
        {
            State = _actionState;
            Message = _Message;
        }
        public void ResponseData()
        {
            var oTT = IsQuery ? OData : this;
            HttpContext.Current.Response.Clear();
            HttpContext.Current.Response.ContentType = "application/json; charset=utf-8";
            HttpContext.Current.Response.Write(oTT);
            HttpContext.Current.Response.End();
        }
    }
    public enum ActionState
    {
        /// <summary>
        /// 0
        /// </summary>
        Succeed,
        /// <summary>
        /// 1
        /// </summary>
        Warning,
        /// <summary>
        /// 2
        /// </summary>
        Error
    }
}