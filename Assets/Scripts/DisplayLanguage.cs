using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MongoDB.Driver;
using MongoDB.Bson;
using System.Threading.Tasks;
using TMPro;

public class DisplayLanguage : MonoBehaviour
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
        collection = db.GetCollection<BsonDocument>("Language");
    }

    // Update is called once per frame
    void Update()
    {
        if ((Input.touchCount > 0) && (Input.GetTouch(0).phase == TouchPhase.Began))
        {
            infomanager.UpdateIconVisibility(transform.name);
            var filter = Builders<BsonDocument>.Filter.Eq("Location", city.text);
            var docs = collection.Find(filter).FirstOrDefault();

            string temp = docs.ToString();
            var stringLangWoId = temp.Substring(temp.IndexOf("),") + 3);
            string stringLangWoLoc = stringLangWoId.Substring(stringLangWoId.IndexOf(",") + 2);
            string language = stringLangWoLoc.Substring(stringLangWoLoc.IndexOf(":") + 2, stringLangWoLoc.IndexOf("}") - stringLangWoLoc.IndexOf(":") - 3);

            Debug.Log(language);
        }
    }



    private void OnMouseDown()
    {
        infomanager.UpdateIconVisibility(transform.name);
        var filter = Builders<BsonDocument>.Filter.Eq("Location", city.text);
        var docs = collection.Find(filter).FirstOrDefault();

        string temp = docs.ToString();
        var stringLangWoId = temp.Substring(temp.IndexOf("),") + 3);
        string stringLangWoLoc = stringLangWoId.Substring(stringLangWoId.IndexOf(",") + 2);
        string language = stringLangWoLoc.Substring(stringLangWoLoc.IndexOf(":") + 2, stringLangWoLoc.IndexOf("}") - stringLangWoLoc.IndexOf(":") - 3);

        Debug.Log(language);
    }

}
