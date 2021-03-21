using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MongoDB.Driver;
using MongoDB.Bson;
using System.Threading.Tasks;
using TMPro;

public class DisplayTD : MonoBehaviour
{
    private InfoManager infomanager;
    public TextMeshPro city;

    MongoClient client = new MongoClient("mongodb+srv://atgarcia:cougarcs@cluster0.tgnzx.mongodb.net/Location_Info?retryWrites=true&w=majority");
    IMongoDatabase db;
    IMongoCollection<BsonDocument> collection;

    // Start is called before the first frame update
    void Start()
    {
        infomanager = FindObjectOfType<InfoManager>();
        db = client.GetDatabase("Location_Info");
        collection = db.GetCollection<BsonDocument>("Top_Destinations");

    }

    // Update is called once per frame
    void Update()
    {
        if ((Input.touchCount > 0) && (Input.GetTouch(0).phase == TouchPhase.Began))
        {
            infomanager.UpdateIconVisibility(transform.name);
            var filter = Builders<BsonDocument>.Filter.Eq("Location", city.text);
            var docs = collection.Find(filter).ToList();

            List<Destinations> rest = new List<Destinations>();
            foreach (var doc in docs)
            {
                rest.Add(GetEachComp(doc.ToString()));
            }

            foreach (var x in rest)
            {
                Debug.Log(x.name + "\n" + x.rating + "\n" + x.tags + "\n" + x.address + "\n" + x.duration + "\n");
            }


        }
    }

    private void OnMouseDown()
    {
        infomanager.UpdateIconVisibility(transform.name);
        var filter = Builders<BsonDocument>.Filter.Eq("Location", city.text);
        var docs = collection.Find(filter).ToList();

        List<Destinations> rest = new List<Destinations>();
        foreach (var doc in docs)
        {
            rest.Add(GetEachComp(doc.ToString()));
        }

        foreach (var x in rest)
        {
            Debug.Log(x.name + "\n" + x.rating + "\n" + x.tags + "\n" + x.address + "\n" + x.duration + "\n");
        }

    }

    public Destinations GetEachComp(string fullLine)
    {
        Destinations input = new Destinations();

        string tdGen = fullLine.Substring(fullLine.IndexOf("),") + 3);

        //TopDestinations Name
        string tdLocName = tdGen.Substring(tdGen.IndexOf(":") + 2, tdGen.IndexOf("}") - tdGen.IndexOf(":") - 3);
        string tdNameTrim = tdLocName.Substring(tdLocName.IndexOf(":") + 2);
        string tdName = tdNameTrim.Substring(0, tdNameTrim.IndexOf(","));
        input.name = tdName;

        //TopDestinations Rating
        string tdLocRatingTemp1 = tdGen.Substring(tdGen.IndexOf(":") + 2);
        string tdLocRatingTemp2 = tdLocRatingTemp1.Substring(tdLocRatingTemp1.IndexOf(":") + 2);
        string tdLocRatingTemp3 = tdLocRatingTemp2.Substring(tdLocRatingTemp2.IndexOf(":") + 2);
        string tdRating = tdLocRatingTemp3.Substring(0, tdLocRatingTemp3.IndexOf(","));
        input.rating = tdRating;

        //TopDestinations Tags
        string tdLocTagsTemp1 = tdGen.Substring(tdGen.IndexOf(":") + 2);
        string tdLocTagsTemp2 = tdLocTagsTemp1.Substring(tdLocTagsTemp1.IndexOf(":") + 2);
        string tdLocTagsTemp3 = tdLocTagsTemp2.Substring(tdLocTagsTemp2.IndexOf(":") + 2);
        string tdLocTagsTemp4 = tdLocTagsTemp3.Substring(tdLocTagsTemp3.IndexOf(":") + 2);
        string tdTags = tdLocTagsTemp4.Substring(0, tdLocTagsTemp4.IndexOf(","));
        input.tags = tdTags;

        //TopDestinations Address
        string tdLocAddTemp1 = tdGen.Substring(tdGen.IndexOf(":") + 2);
        string tdLocAddTemp2 = tdLocAddTemp1.Substring(tdLocAddTemp1.IndexOf(":") + 2);
        string tdLocAddTemp3 = tdLocAddTemp2.Substring(tdLocAddTemp2.IndexOf(":") + 2);
        string tdLocAddTemp4 = tdLocAddTemp3.Substring(tdLocAddTemp3.IndexOf(":") + 2);
        string tdLocAddTemp5 = tdLocAddTemp4.Substring(tdLocAddTemp4.IndexOf(":") + 2);
        string tdAddress = tdLocAddTemp5.Substring(0, tdLocAddTemp5.IndexOf(","));
        input.address = tdAddress;

        //TopDestinations Duration
        string tdLocDurTemp1 = tdGen.Substring(tdGen.IndexOf(":") + 2);
        string tdLocDurTemp2 = tdLocDurTemp1.Substring(tdLocDurTemp1.IndexOf(":") + 2);
        string tdLocDurTemp3 = tdLocDurTemp2.Substring(tdLocDurTemp2.IndexOf(":") + 2);
        string tdLocDurTemp4 = tdLocDurTemp3.Substring(tdLocDurTemp3.IndexOf(":") + 2);
        string tdLocDurTemp5 = tdLocDurTemp4.Substring(tdLocDurTemp4.IndexOf(":") + 2);
        string tdLocDurTemp6 = tdLocDurTemp5.Substring(tdLocDurTemp5.IndexOf(":") + 2);
        string tdDuration = tdLocDurTemp6.Substring(0, tdLocDurTemp6.IndexOf("}"));
        input.duration = tdDuration;

        return input;

    }

    public class Destinations
    {
        public string name;
        public string rating;
        public string tags;
        public string address;
        public string duration;
    }
}