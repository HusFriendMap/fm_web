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
        public IMongoDatabase db { get; private set; }
        public IMongoCollection<BsonDocument> songs { get; private set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            String uri = "mongodb://ducmanhchy:ducmanh1996@ds013951.mlab.com:13951/databasemongo";
            var client = new MongoClient(uri);
            db = client.GetDatabase("databasemongo");
            songs = db.GetCollection<BsonDocument>("songs");

            var result = songs.Find(new BsonDocument()).Project(Builders<BsonDocument>.Projection.Exclude("_id")).ToListAsync().GetAwaiter().GetResult().ToJson();
            var result2 = songs.Find(new BsonDocument()).ToListAsync().GetAwaiter().GetResult();
            var jsonWriterSettings = new JsonWriterSettings { OutputMode = JsonOutputMode.Strict };
            obj = result2.ToJson(jsonWriterSettings);
            //AsyncCrud(seedData).Wait();
            //them(seedData, db);
        }

        private void them(BsonDocument[] seedData)
        {
            songs.InsertManyAsync(seedData);
        }

        public void sua()
        {
            var updateFilter = Builders<BsonDocument>.Filter.Eq("Title", "One Sweet Day");
            var update = Builders<BsonDocument>.Update.Set("Artist", "Mariah Carey ft. Boyz II Men");
            songs.UpdateOneAsync(updateFilter, update);
        }

        // Extra helper code
        static BsonDocument[] CreateSeedData()
        {
            BsonDocument seventies = new BsonDocument {
        { "Decade" , "1970s" },
        { "Artist" , "Debby Boone" },
        { "Title" , "You Light Up My Life" },
        { "WeeksAtOne" , 10 }
      };

            BsonDocument eighties = new BsonDocument {
        { "Decade" , "1980s" },
        { "Artist" , "Olivia Newton-John" },
        { "Title" , "Physical" },
        { "WeeksAtOne" , 10 }
      };

            BsonDocument nineties = new BsonDocument {
        { "Decade" , "1990s" },
        { "Artist" , "Mariah Carey" },
        { "Title" , "One Sweet Day" },
        { "WeeksAtOne" , 16 }
      };

            BsonDocument[] SeedData = { seventies, eighties, nineties };
            return SeedData;
        }

        async static Task AsyncCrud(BsonDocument[] seedData)
        {
            // Create seed data
            BsonDocument[] songData = seedData;

            String uri = "mongodb://ducmanhchy:ducmanh1996@ds013951.mlab.com:13951/databasemongo";

            var client = new MongoClient(uri);
            var db = client.GetDatabase("databasemongo");

            /*
             * First we'll add a few songs. Nothing is required to create the
             * songs collection; it is created automatically when we insert.
             */

            var songs = db.GetCollection<BsonDocument>("songs");

            // Use InsertOneAsync for single BsonDocument insertion.
            await songs.InsertManyAsync(songData);

            /*
             * Then we need to give Boyz II Men credit for their contribution to
             * the hit "One Sweet Day".
             */

            var updateFilter = Builders<BsonDocument>.Filter.Eq("Title", "One Sweet Day");
            var update = Builders<BsonDocument>.Update.Set("Artist", "Mariah Carey ft. Boyz II Men");

            await songs.UpdateOneAsync(updateFilter, update);

            /*
             * Finally we run a query which returns all the hits that spent 10 
             * or more weeks at number 1.
             */

            var filter = Builders<BsonDocument>.Filter.Gte("WeeksAtOne", 10);
            var sort = Builders<BsonDocument>.Sort.Ascending("Decade");

            await songs.Find(filter).Sort(sort).ForEachAsync(song =>
              Console.WriteLine("In the {0}, {1} by {2} topped the charts for {3} straight weeks",
                song["Decade"], song["Title"], song["Artist"], song["WeeksAtOne"])
            );

            // Since this is an example, we'll clean up after ourselves.
            await db.DropCollectionAsync("songs");
        }
        
    }
}