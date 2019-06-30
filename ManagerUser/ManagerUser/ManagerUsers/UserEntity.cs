using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ManagerUser
{
    public class UserEntity : BaseEntity
    {
        public ObjectId _id { get; set; }
        public string Name { get; set; }
        public string LoginName { get; set; }
        public string PassWord { get; set; }
        public int Gender { get; set; }
        public string Email { get; set; }
        //public DateTime DateOfBirth { get; set; }
        //public DateTime? LastLogin { get; set; }
        public string LastLocal { get; set; }
        public string Phone { get; set; }

        public UserEntity() { }
    }
    public class UsersBson : BaseEntity
    {
        [BsonId]
        public ObjectId Id { get; set; }
        [BsonElement("Name")]
        public string Name { get; set; }
        [BsonElement("Email")]
        public string Email { get; set; }
        [BsonElement("Phone")]
        public string Phone { get; set; }
        [BsonElement("LoginName")]
        public string LoginName { get; set; }
        [BsonElement("PassWord")]
        public string PassWord { get; set; }
        [BsonElement("Gender")]
        public int Gender { get; set; }
        [BsonElement("LastLocal")]
        public string LastLocal { get; set; }
        [BsonElement("DateOfBirth")]
        public string DateOfBirth { get; internal set; }
        [BsonElement("LastLogin")]
        public string LastLogin { get; internal set; }
    }
}