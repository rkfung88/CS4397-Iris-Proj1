using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MongoDB.Driver;
using MongoDB.Bson;
using System.Threading.Tasks;
using TMPro;

public class DisplayPD : MonoBehaviour
{
    private InfoManager infomanager;
    public TextMeshPro city;
    public GameObject map;
    public TextMeshPro FinalOutput;
    public List<GameObject> pins;
    MongoClient client = new MongoClient("mongodb+srv://rkfung:test@cluster0.tgnzx.mongodb.net/Location_Info?retryWrites=true&w=majority");
    IMongoDatabase db;
    IMongoCollection<BsonDocument> collection;

    // Start is called before the first frame update
    void Start()
    {
        infomanager = FindObjectOfType<InfoManager>();
        db = client.GetDatabase("Location_Info");
        collection = db.GetCollection<BsonDocument>("Potential Dangers");
        FinalOutput.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if ((Input.touchCount > 0) && (Input.GetTouch(0).phase == TouchPhase.Began))
        {
            infomanager.UpdateIconVisibility(transform.name);
            map.SetActive(false);

            foreach (var pin in pins)
            {
                pin.SetActive(false);
            }

            var filter = Builders<BsonDocument>.Filter.Eq("Location", city.text);
            var studentDocument = collection.Find(filter).FirstOrDefault();

            string temp = studentDocument.ToString();
            var stringWoId = temp.Substring(temp.IndexOf("),") + 4);
            string stringWoLoc = stringWoId.Substring(stringWoId.IndexOf(",") + 3);
            string dangers = stringWoLoc.Substring(stringWoLoc.IndexOf(":") + 2, stringWoLoc.IndexOf("}") - stringWoLoc.IndexOf(":") - 3);

            FinalOutput.color = new Color32(255, 255, 255, 255);
            FinalOutput.fontSize = 9.5f;
            FinalOutput.text = dangers;
            FinalOutput.gameObject.SetActive(true);
        }
    }



    private void OnMouseDown()
    {
        infomanager.UpdateIconVisibility(transform.name);
        map.SetActive(false);

        foreach (var pin in pins)
        {
            pin.SetActive(false);
        }
        var filter = Builders<BsonDocument>.Filter.Eq("Location", city.text);
        var studentDocument = collection.Find(filter).FirstOrDefault();

        string temp = studentDocument.ToString();
        var stringWoId = temp.Substring(temp.IndexOf("),") + 4);
        string stringWoLoc = stringWoId.Substring(stringWoId.IndexOf(",") + 3);
        string dangers = stringWoLoc.Substring(stringWoLoc.IndexOf(":") + 2, stringWoLoc.IndexOf("}") - stringWoLoc.IndexOf(":") - 3);

        FinalOutput.color = new Color32(255, 255, 255, 255);
        FinalOutput.fontSize = 9.5f;
        FinalOutput.text = dangers;
        FinalOutput.gameObject.SetActive(true);

    }

}
