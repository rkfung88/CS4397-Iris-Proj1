using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MongoDB.Driver;
using MongoDB.Bson;
using System.Threading.Tasks;
using TMPro;

public class DisplayRestaurants : MonoBehaviour
{
    private InfoManager infomanager;
    public TextMeshPro city;

    MongoClient client = new MongoClient("mongodb+srv://rkfung:test@cluster0.tgnzx.mongodb.net/Location_Info?retryWrites=true&w=majority");
    IMongoDatabase db;
    IMongoCollection<BsonDocument> collection;

    // Start is called before the first frame update
    void Start()
    {
        infomanager = FindObjectOfType<InfoManager>();
        db = client.GetDatabase("Location_Info");
        collection = db.GetCollection<BsonDocument>("Top_Restaurants");

    }

    // Update is called once per frame
    void Update()
    {
        if ((Input.touchCount > 0) && (Input.GetTouch(0).phase == TouchPhase.Began))
        {
            infomanager.UpdateIconVisibility(transform.name);
            var filter = Builders<BsonDocument>.Filter.Eq("Location", city.text);
            var docs = collection.Find(filter).ToList();

            List<Restaurants> rest = new List<Restaurants>();
            foreach (var doc in docs)
            {
                rest.Add(GetEachComp(doc.ToString()));
            }

            foreach (var x in rest)
            {
                Debug.Log(x.name + "\n" + x.rating + "\n" + x.priceRange + "\n" + x.cuisine + "\n");
            }


        }
    }



    private void OnMouseDown()
    {
        infomanager.UpdateIconVisibility(transform.name);
        var filter = Builders<BsonDocument>.Filter.Eq("Location", city.text);
        var docs = collection.Find(filter).ToList();

        List<Restaurants> rest = new List<Restaurants>();
        foreach (var doc in docs)
        {
            rest.Add(GetEachComp(doc.ToString()));
        }

        foreach (var x in rest)
        {
            Debug.Log(x.name + "\n" + x.rating + "\n" + x.priceRange + "\n" + x.cuisine + "\n");
        }

    }

    public Restaurants GetEachComp(string fullLine)
    {
        Restaurants input = new Restaurants();

        var stringWoId = fullLine.Substring(fullLine.IndexOf("),") + 4);
        string stringWoLoc = stringWoId.Substring(stringWoId.IndexOf(",") + 2);

        string restName = stringWoLoc.Substring(stringWoLoc.IndexOf(":") + 3, stringWoLoc.IndexOf(",") - (stringWoLoc.IndexOf(":") + 4));
        input.name = restName;

        fullLine = stringWoLoc.Substring(stringWoLoc.IndexOf(",") + 1);

        string restRating = fullLine.Substring(fullLine.IndexOf(":") + 3, fullLine.IndexOf(",") - (fullLine.IndexOf(":") + 4));
        input.rating = restRating;

        string temp2 = fullLine.Substring(fullLine.IndexOf(",") + 1);

        string restPrice = temp2.Substring(temp2.IndexOf(":") + 3, temp2.IndexOf(",") - (temp2.IndexOf(":") + 4));
        input.priceRange = restPrice;

        fullLine = temp2.Substring(temp2.IndexOf(",") + 1);

        string restCuisine = fullLine.Substring(0, fullLine.IndexOf("}") - fullLine.IndexOf("C") + 1);
        input.cuisine = restCuisine;

        return input;

    }

    public class Restaurants
    {
        public string name;
        public string rating;
        public string priceRange;
        public string cuisine;
    }
}