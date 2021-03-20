using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MongoDB.Driver;
using MongoDB.Bson;
using System.Threading.Tasks;
using TMPro;

public class BestTimeToVisit : MonoBehaviour
{
    MongoClient client = new MongoClient("mongodb+srv://dvillarreal54:v0808180@cluster0.tgnzx.mongodb.net/Location_Info?retryWrites=true&w=majority");
    IMongoDatabase database;
    IMongoCollection<BsonDocument> collection;
    private TextMeshPro BTVOutput;
    // Start is called before the first frame update
    void Start()
    {
        BTVOutput = GetComponentInChildren<TextMeshPro>();

        database = client.GetDatabase("Location_Info");
        collection = database.GetCollection<BsonDocument>("Weather_BestTimeToVisit");

        var filter = Builders<BsonDocument>.Filter.Eq("Location", "Seoul");
        var studentDocument = collection.Find(filter).FirstOrDefault();
        string temp = studentDocument.ToString();

        var stringWoId = temp.Substring(temp.IndexOf("),") + 4);
        string stringWoLoc = stringWoId.Substring(stringWoId.IndexOf(",") + 3);
        string BTV = stringWoLoc.Substring(stringWoLoc.IndexOf(",") + 3);
        string BTV2 = BTV.Substring(0, BTV.IndexOf(","));
        BTVOutput.text = BTV2;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
