using MongoDB.Bson;

namespace POC_MVC.Models
{
    public interface IBson
    {
        ObjectId _id { get; set; }
    }
}