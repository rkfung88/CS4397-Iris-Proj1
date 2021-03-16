using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MongoDB.Driver;
using MongoDB.Bson;

public class DbAccess : MonoBehaviour
{
    int temp;
    MongoClient client = new MongoClient("mongodb+srv://rkfung:test@cluster0.tgnzx.mongodb.net/Location_Info?retryWrites=true&w=majority");
    IMongoDatabase db;
    IMongoCollection<BsonDocument> collection;

    // Start is called before the first frame update
    void Start()
    {
        db = client.GetDatabase("Location_Info");
        collection = db.GetCollection<BsonDocument>("Timezones");

        var document = new BsonDocument { { "houston", "central standard time" } };
        collection.InsertOne(document);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
