using MongoDB.Bson;
using MongoDB.Bson.IO;
using MongoDB.Driver;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ManagerUser
{
    public partial class Users : System.Web.UI.Page
    {
        public string obj { get; private set; }
        public IMongoCollection<UserEntity> users { get; private set; }
        public UsersDA UsersDA = new UsersDA();
        protected void Page_Load(object sender, EventArgs e)
        {
            users = UsersDA.GetCollection();
            //var result2 = users.Find(Builders<UserEntity>.Filter.Empty).ToListAsync().GetAwaiter().GetResult();
            var result2 = users.Find(FilterDefinition<UserEntity>.Empty).ToListAsync().GetAwaiter().GetResult();
            var jsonWriterSettings = new JsonWriterSettings { OutputMode = JsonOutputMode.Strict };
            obj = result2.ToJson(jsonWriterSettings);
            //AsyncCrud(seedData).Wait();
            //them(seedData, db);
        }
        
        
        async static Task AsyncCrud(UserEntity[] seedData)
        {
            // Create seed data
            UserEntity[] songData = seedData;

            String uri = "mongodb://ducmanhchy:ducmanh1996@ds013951.mlab.com:13951/databasemongo";

            var client = new MongoClient(uri);
            var db = client.GetDatabase("databasemongo");

            /*
             * First we'll add a few users. Nothing is required to create the
             * users collection; it is created automatically when we insert.
             */

            var users = db.GetCollection<UserEntity>("users");

            // Use InsertOneAsync for single UserEntity insertion.
            await users.InsertManyAsync(songData);

            /*
             * Then we need to give Boyz II Men credit for their contribution to
             * the hit "One Sweet Day".
             */
             

            /*
             * Finally we run a query which returns all the hits that spent 10 
             * or more weeks at number 1.
             */

            var filter = Builders<UserEntity>.Filter.Gte("WeeksAtOne", 10);
            var sort = Builders<UserEntity>.Sort.Ascending("Decade");

            //await users.Find(filter).Sort(sort).ForEachAsync(song =>
            //  Console.WriteLine("In the {0}, {1} by {2} topped the charts for {3} straight weeks",
            //    song["Decade"], song["Title"], song["Artist"], song["WeeksAtOne"])
            //);

            // Since this is an example, we'll clean up after ourselves.
            await db.DropCollectionAsync("users");
        }
        
    }
}