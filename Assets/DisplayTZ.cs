using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MongoDB.Driver;
using MongoDB.Bson;
using System.Threading.Tasks;
using TMPro;

public class DisplayTZ : MonoBehaviour
{
    private TimeZoneAccess tzAccess;
    private TextMeshPro tzOutput;

    MongoClient client = new MongoClient("mongodb+srv://rkfung:test@cluster0.tgnzx.mongodb.net/Location_Info?retryWrites=true&w=majority");
    IMongoDatabase db;
    IMongoCollection<BsonDocument> collection;

    // Start is called before the first frame update
    void Start()
    {
  
        tzOutput = GetComponentInChildren<TextMeshPro>();

        db = client.GetDatabase("Location_Info");
        collection = db.GetCollection<BsonDocument>("Timezones");
        var filter = Builders<BsonDocument>.Filter.Eq("Location", "Seoul");
        var studentDocument = collection.Find(filter).FirstOrDefault();
               
        string temp = studentDocument.ToString();
        var stringWoId = temp.Substring(temp.IndexOf("),") + 4);
        string stringWoLoc = stringWoId.Substring(stringWoId.IndexOf(",") + 3);
        string timeDiff = stringWoLoc.Substring(stringWoLoc.IndexOf(":") + 2, stringWoLoc.IndexOf("}")- stringWoLoc.IndexOf(":")-3);
        tzOutput.text = timeDiff;
    }

          
            /*
            private async void displayTimeDiff()
            {
                var task = tzAccess.GetTimeInfo();
                var result = await task;
                var output = " ";
                output = "Timezone: " + " " + result.Conversion;
                tzOutput.text = output;
            }
            */
    }
