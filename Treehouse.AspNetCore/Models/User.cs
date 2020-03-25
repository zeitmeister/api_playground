using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Treehouse.AspNetCore.Models
{
    [BsonIgnoreExtraElements]
    public class User
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public bool isVerified { get; set; }

        
        [NotMapped]
        public string[] answersVoted { get; set; }
        public string MongoNr { get; set; }
        public string username { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public int __v { get; set; }
        public ICollection<Token> tokens { get; set; }
    }

    public class Token
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string token { get; set; }
    }

}
