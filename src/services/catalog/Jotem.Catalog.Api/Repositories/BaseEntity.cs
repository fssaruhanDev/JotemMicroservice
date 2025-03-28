using MongoDB.Bson.Serialization.Attributes;

namespace Jotem.Catalog.Api.Repositories
{
    public class BaseEntity
    {
        [BsonElement("_id")]
        public Guid Id { get; set; }


    }
}
