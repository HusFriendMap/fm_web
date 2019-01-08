using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ManagerUser
{
    //class Pass
    //{
    //    public ObjectId _id { get; set; }
    //    public Guid PassId { get; set; }
    //    public string Place { get; set; }
    //    public string Pectoral { get; set; }
    //    public DateTime Time { get; set; }

    //    public override string ToString()
    //    {
    //        return $"PassId: {PassId.ToString()}, Place: {Place}, Pectoral: {Pectoral}, Time: {Time.ToString("u")}";
    //    }
    //}

    //class Program
    //{
    //    static void Main(string[] args)
    //    {
    //        //Connection String: you can retrieve the connection string from the mlab portal inside the Users section
    //        ///https://mlab.com/databases/dbname#users
    //        const string CONNSTRING = "mongodb://device01:asdasd.1@ds05943.mlab.com:59165/test001";

    //        //The name of the database
    //        const string DBNAME = "test001";

    //        //The name of the collection
    //        const string COLL = "Collection02";

    //        //Creating client using the connection string
    //        var client = new MongoClient(CONNSTRING);

    //        //Getting Database
    //        var db = client.GetDatabase(DBNAME);

    //        //Getting the Collection
    //        var coll = db.GetCollection<Pass>(COLL);

    //        //Calling some example functions

    //        Console.WriteLine(getCount(coll).ToString());

    //        Console.WriteLine("Inserting 1 item");
    //        insert(coll);

    //        Console.WriteLine("Inserting many items");
    //        insertMany(coll);

    //        Console.WriteLine("Getting items");
    //        var passes = getWithFiltersAndSort(coll);
    //        passes.ForEach(pa => Console.WriteLine(pa.ToString()));

    //        Console.WriteLine("Getting first item");
    //        var pass = getFirst(coll);
    //        Console.WriteLine(pass.ToString());

    //        Console.WriteLine("Updating item");
    //        pass.Time = DateTime.UtcNow;
    //        update(coll, pass);

    //        Console.WriteLine("Deleting item");
    //        delete(coll, pass);

    //        Console.WriteLine(getCount(coll).ToString());

    //        Console.ReadLine();
    //    }

    //    /// <summary>
    //    /// Returns the number of items inside the collection
    //    /// </summary>
    //    /// <param name="coll"></param>
    //    /// <returns></returns>
    //    private static Int64 getCount(IMongoCollection<Pass> coll)
    //    {
    //        return coll.Count(FilterDefinition<Pass>.Empty);
    //    }

    //    /// <summary>
    //    /// Delete the entity specified by a PassId value
    //    /// </summary>
    //    /// <param name="coll"></param>
    //    /// <param name="pass"></param>
    //    private static void delete(IMongoCollection<Pass> coll, Pass pass)
    //    {
    //        coll.DeleteOne(Builders<Pass>.Filter.Eq(pa => pa.PassId, pass.PassId));
    //    }

    //    /// <summary>
    //    /// Update an entity using the new passed Object
    //    /// </summary>
    //    /// <param name="coll"></param>
    //    /// <param name="pass"></param>
    //    private static void update(IMongoCollection<Pass> coll, Pass pass)
    //    {
    //        coll.ReplaceOne(Builders<Pass>.Filter.Eq(pa => pa.PassId, pass.PassId), pass);
    //    }

    //    /// <summary>
    //    /// Return the first item of the collection
    //    /// </summary>
    //    /// <param name="coll"></param>
    //    /// <returns></returns>
    //    private static Pass getFirst(IMongoCollection<Pass> coll)
    //    {
    //        return coll.Find(FilterDefinition<Pass>.Empty).FirstOrDefault();
    //    }

    //    /// <summary>
    //    /// Return the list of entities with respond to specific search criteria
    //    /// (Place and Time)
    //    /// </summary>
    //    /// <param name="coll"></param>
    //    /// <returns></returns>
    //    private static List<Pass> getWithFiltersAndSort(IMongoCollection<Pass> coll)
    //    {
    //        var filter1 = Builders<Pass>.Filter.Eq(pa => pa.Place, "Place 1");
    //        var filter2 = Builders<Pass>.Filter.Gt(pa => pa.Time, DateTime.UtcNow.AddMinutes(-15));
    //        var filter3 = filter1 & filter2;
    //        var sort = Builders<Pass>.Sort.Descending(pa => pa.Time);

    //        return coll.Find(filter3).Sort(sort).ToList();
    //    }

    //    /// <summary>
    //    /// Insert a lot of random entities
    //    /// </summary>
    //    /// <param name="coll"></param>
    //    private static void insertMany(IMongoCollection<Pass> coll)
    //    {
    //        Random r = new Random();

    //        var passes = new List<Pass>();
    //        for (int i = 0; i < 10000; i++)
    //        {
    //            Pass p1 = new MongoDB.Pass()
    //            {
    //                PassId = Guid.NewGuid(),
    //                Pectoral = r.Next(1, 100).ToString(),
    //                Place = "Place " + r.Next(1, 5),
    //                Time = DateTime.UtcNow
    //            };

    //            passes.Add(p1);
    //        }

    //        coll.InsertMany(passes);
    //    }

    //    /// <summary>
    //    /// Insert a single random entity
    //    /// </summary>
    //    /// <param name="coll"></param>
    //    private static void insert(IMongoCollection<Pass> coll)
    //    {
    //        Random r = new Random();
    //        Pass p = new MongoDB.Pass()
    //        {
    //            PassId = Guid.NewGuid(),
    //            Pectoral = r.Next(1, 100).ToString(),
    //            Place = "Place " + r.Next(1, 5),
    //            Time = DateTime.UtcNow
    //        };

    //        coll.InsertOne(p);
    //    }
    //}

}