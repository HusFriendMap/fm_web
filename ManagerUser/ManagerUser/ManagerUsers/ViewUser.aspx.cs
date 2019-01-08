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
    public partial class ViewUser : System.Web.UI.Page
    {
        public UsersDA UsersDA = new UsersDA();
        public UserEntity oUser { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            var _id = Request["_id"];
            var filter = Builders<UserEntity>.Filter.Eq("_id", new ObjectId(_id));
            oUser = UsersDA.GetCollection().Find(filter).FirstOrDefault();

            //await songs.Find(filter).Sort(sort).ForEachAsync(song =>
            //  Console.WriteLine("In the {0}, {1} by {2} topped the charts for {3} straight weeks",
            //    song["Decade"], song["Title"], song["Artist"], song["WeeksAtOne"])
            //);
        }
    }
}