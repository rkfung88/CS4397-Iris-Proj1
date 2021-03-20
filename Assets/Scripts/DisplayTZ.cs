using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MongoDB.Driver;
using MongoDB.Bson;
using System.Threading.Tasks;
using TMPro;


public class DisplayTZ : MonoBehaviour
{
    private InfoManager infomanager;
    public GameObject uiHolder;

    MongoClient client = new MongoClient("mongodb+srv://rkfung:test@cluster0.tgnzx.mongodb.net/Location_Info?retryWrites=true&w=majority");
    IMongoDatabase db;
    IMongoCollection<BsonDocument> collection;
    


    // Start is called before the first frame update
    void Start()
    {
        infomanager = FindObjectOfType<InfoManager>();

        db = client.GetDatabase("Location_Info");
        collection = db.GetCollection<BsonDocument>("Timezones");
/*
        Debug.Log(uiHolder.ToString());

        var filter = Builders<BsonDocument>.Filter.Eq("Location", "Seoul");
        var studentDocument = collection.Find(filter).FirstOrDefault();
               
        string temp = studentDocument.ToString();
        var stringWoId = temp.Substring(temp.IndexOf("),") + 4);
        string stringWoLoc = stringWoId.Substring(stringWoId.IndexOf(",") + 3);
        string timeDiff = stringWoLoc.Substring(stringWoLoc.IndexOf(":") + 2, stringWoLoc.IndexOf("}")- stringWoLoc.IndexOf(":")-3);
*/
    }

    void Update()
    {
        

        var filter = Builders<BsonDocument>.Filter.Eq("Location", "Seoul");
        var studentDocument = collection.Find(filter).FirstOrDefault();

        string temp = studentDocument.ToString();
        var stringWoId = temp.Substring(temp.IndexOf("),") + 4);
        string stringWoLoc = stringWoId.Substring(stringWoId.IndexOf(",") + 3);
        string timeDiff = stringWoLoc.Substring(stringWoLoc.IndexOf(":") + 2, stringWoLoc.IndexOf("}") - stringWoLoc.IndexOf(":") - 3);

    }

          
          
    }
