using MongoDB.Bson;

namespace POC_API.Models
{
    public interface IBson
    {
        ObjectId _id { get; set; }
    }
}