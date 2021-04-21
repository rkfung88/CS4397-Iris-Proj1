using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;
using TMPro;
using System.Text;
using UnityEngine.Networking;

public class DisplayRestaurants : MonoBehaviour
{
    private InfoManager infomanager;
    private RestHTTP rest;
    public TextMeshPro city;
    public TextMeshPro FinalOutput;
    public GameObject map;
    public List<GameObject> pins;

    // Start is called before the first frame update
    void Start()
    {
        infomanager = FindObjectOfType<InfoManager>();
        rest = new RestHTTP();
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

            rest.Location = city.text;
            StartCoroutine(GetRestaurants(rest.Location, result =>
            {
                FinalOutput.color = new Color32(255, 255, 255, 255);
                FinalOutput.fontSize = 8.5f;
                FinalOutput.text += result.Cuisine + "\n" + result.Foods + "\n" + result.Rest + "\n\n";
                FinalOutput.gameObject.SetActive(true);


            }));



            //Ray raycast = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
            //RaycastHit raycastHit;
            //if (Physics.Raycast(raycast, out raycastHit))
            //{
            //    Debug.Log("3");
            //    //if (raycastHit.collider.name == "Map")
            //    //{
            //    //    Debug.Log("Map clicked");
            //    //}

            //    //OR with Tag

            //    if (raycastHit.collider.CompareTag("Restaurants"))
            //    {
            //        Debug.Log("Restaurants");
            //        infomanager.UpdateIconVisibility(transform.name);
            //        map.SetActive(false);

            //        foreach (var pin in pins)
            //        {
            //            pin.SetActive(false);
            //        }

            //        var filter = Builders<BsonDocument>.Filter.Eq("Location", city.text);
            //        var docs = collection.Find(filter).ToList();

            //        List<Restaurants> rest = new List<Restaurants>();
            //        foreach (var doc in docs)
            //        {
            //            rest.Add(GetEachComp(doc.ToString()));
            //        }

            //        FinalOutput.fontSize = 7.5f;
            //        foreach (var x in rest)
            //        {
            //            FinalOutput.text += x.name + "\n" + x.rating + "\n" + x.priceRange + "\n" + x.cuisine + "\n\n";
            //        }

            //        FinalOutput.color = new Color32(255, 255, 255, 255);
            //        FinalOutput.fontSize = 15.0f;
            //        FinalOutput.gameObject.SetActive(true);
            //    }
            //}
        }
    }



    private void OnMouseDown()
    {
        infomanager.UpdateIconVisibility(transform.name);
        map.SetActive(false);

        foreach(var pin in pins)
        {
            pin.SetActive(false);
        }
        rest.Location = city.text;
        StartCoroutine(GetRestaurants(rest.Location, result =>
        {
            FinalOutput.color = new Color32(255, 255, 255, 255);
            FinalOutput.fontSize = 8.5f;
            FinalOutput.text += result.Cuisine + "\n" + result.Foods + "\n" + result.Rest + "\n\n";
            FinalOutput.gameObject.SetActive(true);


        }));



    }

    IEnumerator GetRestaurants(string id, System.Action<RestHTTP> callback = null)
    {
        using (UnityWebRequest request = UnityWebRequest.Get("https://us-east-1.aws.webhooks.mongodb-realm.com/api/client/v2.0/app/destin_info-uhypn/service/Info_Center/incoming_webhook/get_restaurants?Location=" + id))
        {
            yield return request.SendWebRequest();

            if (request.isNetworkError || request.isHttpError)
            {
                Debug.Log(request.error);
                if (callback != null)
                {
                    callback.Invoke(null);
                }
            }
            else
            {
                if (callback != null)
                {
                    callback.Invoke(RestHTTP.Parse(request.downloadHandler.text));
                }
            }
        }
    }
  }


