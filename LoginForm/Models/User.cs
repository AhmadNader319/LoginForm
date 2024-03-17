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
        public string Name { get; set; } = "Namon";

        [BsonElement("Password")]
        public string Password { get; set; } = "Passwordon";
    }
}

