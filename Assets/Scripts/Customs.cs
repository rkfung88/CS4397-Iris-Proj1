using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;
using TMPro;
using System.Text;
using UnityEngine.Networking;


public class Customs : MonoBehaviour
{
    private InfoManager infomanager;
    private CustomsHTTP customs;
    public TextMeshPro city;
    public GameObject map;
    public TextMeshPro FinalOutput;
    public List<GameObject> pins;

    // Start is called before the first frame update
    void Start()
    {
        infomanager = FindObjectOfType<InfoManager>();
        customs = new CustomsHTTP();
        FinalOutput.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if ((Input.touchCount > 0) && (Input.GetTouch(0).phase == TouchPhase.Began))
        {
            //infomanager.UpdateIconVisibility(transform.name);
            customs.Location = city.text;
            map.SetActive(true);

            foreach (var pin in pins)
            {
                pin.SetActive(false);
            }

            StartCoroutine(GetCustoms(customs.Location, result =>
            {
                FinalOutput.color = new Color32(0, 0, 0, 255);
                FinalOutput.fontSize = 5.5f;
                FinalOutput.text = result.Customs;
                FinalOutput.gameObject.SetActive(true);

            }));


        }
    }



    private void OnMouseDown()
    {
        //infomanager.UpdateIconVisibility(transform.name);
        customs.Location = city.text;
        map.SetActive(true);

        foreach (var pin in pins)
        {
            pin.SetActive(false);
        }

        StartCoroutine(GetCustoms(customs.Location, result =>
        {
            FinalOutput.color = new Color32(0, 0, 0, 255);
            FinalOutput.fontSize = 5.5f;
            FinalOutput.text = result.Customs;
            FinalOutput.gameObject.SetActive(true);

        }));


    }

    IEnumerator GetCustoms(string id, System.Action<CustomsHTTP> callback = null)
    {
        using (UnityWebRequest request = UnityWebRequest.Get("https://us-east-1.aws.webhooks.mongodb-realm.com/api/client/v2.0/app/destin_info-uhypn/service/Info_Center/incoming_webhook/get_Customs?Location=" + id))
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
                    callback.Invoke(CustomsHTTP.Parse(request.downloadHandler.text));
                    //Debug.Log(request.downloadHandler.text);
                }
            }
        }
    }


}


