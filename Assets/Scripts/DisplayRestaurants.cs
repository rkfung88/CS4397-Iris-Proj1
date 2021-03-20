using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MongoDB.Driver;
using MongoDB.Bson;
using System.Threading.Tasks;
using TMPro;

public class DisplayRestaurants : MonoBehaviour
{
    private TextMeshPro tzOutput;

    MongoClient client = new MongoClient("mongodb+srv://rkfung:test@cluster0.tgnzx.mongodb.net/Location_Info?retryWrites=true&w=majority");
    IMongoDatabase db;
    IMongoCollection<BsonDocument> collection;

    // Start is called before the first frame update
    void Start()
    {
        db = client.GetDatabase("Location_Info");
        collection = db.GetCollection<BsonDocument>("Top_Restaurants");

        var filter = Builders<BsonDocument>.Filter.Eq("Location", "Seoul");
        var doc = collection.Find(filter).FirstOrDefault();

        string temp = doc.ToString();
        var stringWoId = temp.Substring(temp.IndexOf("),") + 4);
        string stringWoLoc = stringWoId.Substring(stringWoId.IndexOf(",") + 2);
        Debug.Log(stringWoLoc);

        string restName = stringWoLoc.Substring(stringWoLoc.IndexOf(":") + 3, stringWoLoc.IndexOf(",") - (stringWoLoc.IndexOf(":")+4));
        Debug.Log(restName);

        temp = stringWoLoc.Substring(stringWoLoc.IndexOf(",") + 1);
        //Debug.Log(temp);

        string restRating = temp.Substring(temp.IndexOf(":") + 3, temp.IndexOf(",") - (temp.IndexOf(":") + 4));
        Debug.Log(restRating);

        string temp2 = temp.Substring(temp.IndexOf(",") + 1);

        string restPrice = temp2.Substring(temp2.IndexOf(":") + 3, temp2.IndexOf(",") - (temp2.IndexOf(":") + 4));
        Debug.Log(restPrice);

        temp = temp2.Substring(temp2.IndexOf(",") + 1);
        // Debug.Log(temp); 

        string restCuisine = temp.Substring(0, temp.IndexOf("}") - temp.IndexOf("C") + 1);
        Debug.Log(restCuisine);





    }

    // Update is called once per frame
    void Update()
    {

    }
}
