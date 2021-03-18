using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MongoDB.Driver;
using MongoDB.Bson;
using System.Threading.Tasks;

public class TimeZoneAccess : MonoBehaviour
{
    MongoClient client = new MongoClient("mongodb+srv://rkfung:test@cluster0.tgnzx.mongodb.net/Location_Info?retryWrites=true&w=majority");
    IMongoDatabase db;
    IMongoCollection<BsonDocument> collection;
    
    // Start is called before the first frame update
    void Start()
    {
        db = client.GetDatabase("Location_Info");
        collection = db.GetCollection<BsonDocument>("Timezones");
/*
        var filter = Builders<BsonDocument>.Filter.Eq("Location", "Tokyo");
        var studentDocument = collection.Find(filter).FirstOrDefault();
        Debug.Log(studentDocument.ToString());

        string temp = studentDocument.ToString();
        var stringWoId = temp.Substring(temp.IndexOf("),") + 4);
        Debug.Log(stringWoId);

        string stringWoLoc = stringWoId.Substring(stringWoId.IndexOf(",") + 3);
        Debug.Log(stringWoLoc);

        string timeDiff = stringWoLoc.Substring(stringWoLoc.IndexOf(":") + 2, stringWoLoc.IndexOf("}")- stringWoLoc.IndexOf(":")-3);
        Debug.Log(timeDiff);



        //var document = new BsonDocument { { "hong kong", " sometime" } };
        //collection.InsertOne(document);
*/
    }
    
    public async Task<Timezones> GetTimeInfo()
    {
        var filter = Builders<BsonDocument>.Filter.Eq("Location", "Tokyo");
        var document = collection.Find(filter).FirstOrDefaultAsync();
        var cityTzAwaited = await document;
        Debug.Log(cityTzAwaited.ToString());

        Timezones TzInfo = new Timezones();
        
        TzInfo = Deserialize(document.ToString());
        
        return TzInfo;
    }
    
    private Timezones Deserialize(string v)
    {
        var tz = new Timezones();

        var stringWoId = v.Substring(v.IndexOf("),") + 4);
        string stringWoLoc = stringWoId.Substring(stringWoId.IndexOf(",") + 3);
        string timeDiff = stringWoLoc.Substring(stringWoLoc.IndexOf(":") + 2, stringWoLoc.IndexOf("}") - stringWoLoc.IndexOf(":") - 3);
        tz.Conversion = timeDiff;

        return tz;
    }

    public class Timezones
    {
        public string Conversion { get; set; }

    }


}
