using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;


namespace LoginForm.Models
{
    [BsonIgnoreExtraElements]
    public class User
	{
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } = string.Empty;

        [BsonElement("Name")]
        public string FirstName { get; set; } = "Student Name";

        [BsonElement("Password")]
        public string LastName { get; set; } = "Student Password";
    }
}

