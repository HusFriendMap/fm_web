using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ManagerUser
{
    public partial class pFormUser : System.Web.UI.Page
    {
        public UsersDA UsersDA = new UsersDA();
        public new UserEntity User = new UserEntity();
        public string action { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            var _id = Request["_id"];
            action = Request["do"];
            if (!string.IsNullOrEmpty(_id))
            {
                var filter = Builders<UserEntity>.Filter.Eq("_id", new ObjectId(_id));
                User = new UserEntity();
                User = UsersDA.GetCollection().Find(filter).FirstOrDefault();
            }
        }
    }
}