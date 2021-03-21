﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MongoDB.Driver;
using MongoDB.Bson;
using System.Threading.Tasks;
using TMPro;

public class DisplayCurrency : MonoBehaviour
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
        collection = db.GetCollection<BsonDocument>("Currency");
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
            var stringCurrWoId = temp.Substring(temp.IndexOf("),") + 3);
            string stringCurrWoLoc = stringCurrWoId.Substring(stringCurrWoId.IndexOf(",") + 2);
            string currency = stringCurrWoLoc.Substring(stringCurrWoLoc.IndexOf(":") + 2, stringCurrWoLoc.IndexOf("}") - stringCurrWoLoc.IndexOf(":") - 3);

            Debug.Log(currency);
        }
    }



    private void OnMouseDown()
    {
        infomanager.UpdateIconVisibility(transform.name);
        var filter = Builders<BsonDocument>.Filter.Eq("Location", city.text);
        var docs = collection.Find(filter).FirstOrDefault();

        string temp = docs.ToString();
        var stringCurrWoId = temp.Substring(temp.IndexOf("),") + 3);
        string stringCurrWoLoc = stringCurrWoId.Substring(stringCurrWoId.IndexOf(",") + 2);
        string currency = stringCurrWoLoc.Substring(stringCurrWoLoc.IndexOf(":") + 2, stringCurrWoLoc.IndexOf("}") - stringCurrWoLoc.IndexOf(":") - 3);

        Debug.Log(currency);

    }

}