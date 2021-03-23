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
    public TextMeshPro FinalOutput;

    MongoClient client = new MongoClient("mongodb+srv://atgarcia:cougarcs@cluster0.tgnzx.mongodb.net/Location_Info?retryWrites=true&w=majority");
    IMongoDatabase db;
    IMongoCollection<BsonDocument> collection;

    // Start is called before the first frame update
    void Start()
    {
        infomanager = FindObjectOfType<InfoManager>();
        db = client.GetDatabase("Location_Info");
        collection = db.GetCollection<BsonDocument>("Language");
        FinalOutput.gameObject.SetActive(false);
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

            FinalOutput.text = language;

            FinalOutput.gameObject.SetActive(true);
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

        FinalOutput.fontSize = 20f;

        FinalOutput.text = language;

        FinalOutput.gameObject.SetActive(true);
    }

}
