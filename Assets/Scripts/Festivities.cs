using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MongoDB.Driver;
using MongoDB.Bson;
using System.Threading.Tasks;
using TMPro;

public class Festivities : MonoBehaviour
{
    private InfoManager infomanager;
    public TextMeshPro city;
    MongoClient client = new MongoClient("mongodb+srv://dvillarreal54:v0808180@cluster0.tgnzx.mongodb.net/Location_Info?retryWrites=true&w=majority");
    IMongoDatabase database;
    IMongoCollection<BsonDocument> collection;
    //private TextMeshPro fOutput;
    // Start is called before the first frame update
    void Start()
    {
        infomanager = FindObjectOfType<InfoManager>();
        database = client.GetDatabase("Location_Info");
        collection = database.GetCollection<BsonDocument>("Weather_BestTimeToVisit");
    }

    // Update is called once per frame
    void Update()
    {
        if ((Input.touchCount > 0) && (Input.GetTouch(0).phase == TouchPhase.Began))
        {
            infomanager.UpdateIconVisibility(transform.name);
            var filter = Builders<BsonDocument>.Filter.Eq("Location", city.text);
            var studentDocument = collection.Find(filter).FirstOrDefault();
            string temp = studentDocument.ToString();

            var stringWoId = temp.Substring(temp.IndexOf("),") + 4);
            string stringWoLoc = stringWoId.Substring(stringWoId.IndexOf(",") + 3);
            string BTV = stringWoLoc.Substring(stringWoLoc.IndexOf(",") + 3);
            string Festivities = BTV.Substring(BTV.IndexOf(",") + 3);
            string BTV2 = BTV.Substring(0, BTV.IndexOf(","));
            string Festivities2 = Festivities.Substring(0, Festivities.IndexOf(","));

            Debug.Log(Festivities2);
        }
    }

    private void OnMouseDown()
    {
        infomanager.UpdateIconVisibility(transform.name);
        var filter = Builders<BsonDocument>.Filter.Eq("Location", city.text);
        var studentDocument = collection.Find(filter).FirstOrDefault();
        string temp = studentDocument.ToString();

        var stringWoId = temp.Substring(temp.IndexOf("),") + 4);
        string stringWoLoc = stringWoId.Substring(stringWoId.IndexOf(",") + 3);
        string BTV = stringWoLoc.Substring(stringWoLoc.IndexOf(",") + 3);
        string Festivities = BTV.Substring(BTV.IndexOf(",") + 3);
        string BTV2 = BTV.Substring(0, BTV.IndexOf(","));
        string Festivities2 = Festivities.Substring(0, Festivities.IndexOf(","));

        Debug.Log(Festivities2);

    }
}
