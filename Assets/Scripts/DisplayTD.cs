using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;
using TMPro;
using System.Text;
using UnityEngine.Networking;

public class DisplayTD : MonoBehaviour
{
    private Touch theTouch;
    private float timeTouchEnded;
    private float displayedTime = 0.5f;

    private InfoManager infomanager;
    private DestinHTTP destinations;
    public TextMeshPro city;
    public TextMeshPro FinalOutput;
    public GameObject map;
    public List<GameObject> pins;


    // Start is called before the first frame update
    void Start()
    {
        infomanager = FindObjectOfType<InfoManager>();
        destinations = new DestinHTTP();
        FinalOutput.gameObject.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        if ((Input.touchCount > 0) && (Input.GetTouch(0).phase == TouchPhase.Began))
        {
            //Ray raycast = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
            //RaycastHit raycastHit;
            //if (Physics.Raycast(raycast, out raycastHit))
            //{
            //    Debug.Log("2");
            //    //if (raycastHit.collider.name == "Map")
            //    //{
            //    //    Debug.Log("Map clicked");
            //    //}

            //    //OR with Tag

            //    if (raycastHit.collider.CompareTag("TravelPlaces"))
            //    {
            //        Debug.Log("TravelPlaces");
            //        OnMouseDown();
            //    }
            //}

            //infomanager.UpdateIconVisibility(transform.name);
            map.SetActive(false);

            foreach (var pin in pins)
            {
                pin.SetActive(false);
            }

            destinations.Location = city.text;
            StartCoroutine(GetDestin(destinations.Location, result =>
            {
                FinalOutput.color = new Color32(0, 0, 0, 255);
                FinalOutput.fontSize = 5.0f;
                FinalOutput.text += result.Known_For + "\n" + result.Places + "\n\n";
                FinalOutput.gameObject.SetActive(true);


            }));

        }
    }

    private void OnMouseDown()
    {
        //infomanager.UpdateIconVisibility(transform.name);

        map.SetActive(false);

        foreach (var pin in pins)
        {
            pin.SetActive(false);
        }

        destinations.Location = city.text;
        StartCoroutine(GetDestin(destinations.Location, result =>
        {
            FinalOutput.color = new Color32(0, 0, 0, 255);
            FinalOutput.fontSize = 5.0f;
            FinalOutput.text += result.Known_For + "\n" + result.Places + "\n\n";
            FinalOutput.gameObject.SetActive(true);


        }));
    }

    IEnumerator GetDestin(string id, System.Action<DestinHTTP> callback = null)
    {
        using (UnityWebRequest request = UnityWebRequest.Get("https://us-east-1.aws.webhooks.mongodb-realm.com/api/client/v2.0/app/destin_info-uhypn/service/Info_Center/incoming_webhook/get_Destinations?Location=" + id))
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
                    callback.Invoke(DestinHTTP.Parse(request.downloadHandler.text));
                }
            }
        }
    }

}