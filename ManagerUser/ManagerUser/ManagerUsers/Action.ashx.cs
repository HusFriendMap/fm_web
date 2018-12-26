using MongoDB.Bson;
using MongoDB.Bson.IO;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;

namespace ManagerUser
{
    /// <summary>
    /// Summary description for Action
    /// </summary>
    public class Action : pActionBase
    {
        ResultAction oResult = new ResultAction();
        public IMongoCollection<UserEntity> users { get; private set; }
        public IMongoCollection<UsersBson> Users { get; private set; }
        UserEntity user = new UserEntity();
        UsersBson User = new UsersBson();
        public UsersDA UsersDA = new UsersDA();
        public override void ProcessRequest(HttpContext context)
        {
            base.ProcessRequest(context);
            switch (DoAction.ToUpper())
            {
                case "QUERYDATA":
                    users = UsersDA.GetCollection();
                    var result2 = users.Find(FilterDefinition<UserEntity>.Empty).ToListAsync().GetAwaiter().GetResult();
                    var jsonWriterSettings = new JsonWriterSettings { OutputMode = JsonOutputMode.Strict };
                    oResult.OData = result2.ToJson(jsonWriterSettings);
                    break;
                case "UPDATE":
                    Users = UsersDA.GetCollectionBson();
                    User.UpdateObject(context.Request);
                    if (!ObjectId.TryParse(_id, out ObjectId objectid))
                        objectid = ObjectId.Empty;
                    if (objectid != ObjectId.Empty)
                    {
                        var updateFilter = Builders<UsersBson>.Filter.Eq("_id", BsonObjectId.Create(objectid));
                        var updateValues = new List<UpdateDefinition<UsersBson>>();
                        if (!string.IsNullOrEmpty(User.Name)) { updateValues.Add(Builders<UsersBson>.Update.Set("Name", User.Name)); }
                        if (!string.IsNullOrEmpty(User.LoginName)) { updateValues.Add(Builders<UsersBson>.Update.Set("LoginName", User.LoginName)); }
                        if (!string.IsNullOrEmpty(User.PassWord)) { updateValues.Add(Builders<UsersBson>.Update.Set("PassWord", User.PassWord)); }
                        if (!string.IsNullOrEmpty(User.DateOfBirth)) { updateValues.Add(Builders<UsersBson>.Update.Set("DateOfBirth", User.DateOfBirth)); }
                        if (Convert.ToInt32(User.Gender) > 0) { updateValues.Add(Builders<UsersBson>.Update.Set("Gender", User.Gender)); }
                        if (!string.IsNullOrEmpty(User.LastLogin)) { updateValues.Add(Builders<UsersBson>.Update.Set("LastLogin", User.LastLogin)); }
                        UpdateDefinition<UsersBson> update = Builders<UsersBson>.Update.Combine(updateValues);
                        Users.UpdateOne(updateFilter, update);
                    }
                    else
                    {
                        Users.InsertOneAsync(User);
                    }
                    oResult.Message = "Lưu thành công";
                    break;
                case "DELETE":
                    {
                        string outb = UsersDA.DeleteUserById(_id);
                        if (string.IsNullOrEmpty(outb))
                            oResult.Message = "Xóa thành công";
                        else oResult.Message = outb;
                        break;
                    }
                case "DELETE-MULTI":
                    break;
            }
            oResult.ResponseData();
        }
    }
}