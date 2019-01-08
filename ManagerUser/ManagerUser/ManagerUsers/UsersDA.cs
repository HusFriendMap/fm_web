using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ManagerUser
{
    public class UsersDA : BaseDA
    {
        public IMongoCollection<UserEntity> users { get; private set; }
        public IMongoCollection<UsersBson> Users { get; private set; }
        public string uri = "mongodb://ducmanhchy:ducmanh1996@ds013951.mlab.com:13951/databasemongo";
        public IMongoDatabase db { get; private set; }

        public IMongoCollection<UserEntity> GetCollection()
        {
            var client = new MongoClient(uri);
            db = client.GetDatabase("databasemongo");
            users = db.GetCollection<UserEntity>("users");
            return users;
        }
        public IMongoCollection<UsersBson> GetCollectionBson()
        {
            var client = new MongoClient(uri);
            db = client.GetDatabase("databasemongo");
            Users = db.GetCollection<UsersBson>("users");
            return Users;
        }
        #region Delete Users
        public string DeleteUserById(string id)
        {
            try
            {
                GetCollectionBson();
                var filter = Builders<UsersBson>.Filter.Eq("_id", new ObjectId(id));
                var result = Users.DeleteOneAsync(filter);
            }
            catch (Exception ex)
            {
                return ex.ToString();
            }
            return null;
        }

        public async Task<long> DeleteAllUsers()
        {
            var filter = new BsonDocument();
            var result = await Users.DeleteManyAsync(filter);
            return result.DeletedCount;
        }
        #endregion
        #region Read Users
        public async Task<List<UsersBson>> GetAllUsers()
        {
            return await Users.Find(new BsonDocument()).ToListAsync();
        }

        public async Task<List<UsersBson>> GetUsersByField(string fieldName, string fieldValue)
        {
            var filter = Builders<UsersBson>.Filter.Eq(fieldName, fieldValue);
            var result = await Users.Find(filter).ToListAsync();

            return result;
        }

        public async Task<List<UsersBson>> GetUsers(int startingFrom, int count)
        {
            var result = await Users.Find(new BsonDocument())
                                               .Skip(startingFrom)
                                               .Limit(count)
                                               .ToListAsync();

            return result;
        }
        #endregion
        #region Update User
        public async Task<bool> UpdateUser(ObjectId id, string udateFieldName, string updateFieldValue)
        {
            var filter = Builders<UsersBson>.Filter.Eq("_id", id);
            var update = Builders<UsersBson>.Update.Set(udateFieldName, updateFieldValue);

            var result = await Users.UpdateOneAsync(filter, update);

            return result.ModifiedCount != 0;
        }

        //var users1 = await Users.GetUsersByField("name", "Nikola");
        //var user1 = users1.FirstOrDefault();

        //var result1 = await Users.UpdateUser(user1.Id, "address", "test address");
        #endregion

    }
}