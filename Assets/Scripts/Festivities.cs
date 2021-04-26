using System.Collections;
using System.Collections.Generic;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;
using TMPro;
using System.Text;
using UnityEngine.Networking;


public class Festivities : MonoBehaviour
{
    private InfoManager infomanager;
    private WeatherHTTP weather;
    public TextMeshPro city;
    public GameObject map;
    public TextMeshPro FinalOutput;

    void Start()
    {
        infomanager = FindObjectOfType<InfoManager>();
        weather = new WeatherHTTP();
        FinalOutput.gameObject.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        if ((Input.touchCount > 0) && (Input.GetTouch(0).phase == TouchPhase.Began))
        {
            //infomanager.UpdateIconVisibility(transform.name);
            weather.Location = city.text;
            StartCoroutine(GetFest(weather.Location, result =>
            {
                FinalOutput.color = new Color32(0, 0, 0, 255);
                FinalOutput.fontSize = 15.0f;
                FinalOutput.text = result.AI;
                FinalOutput.gameObject.SetActive(true);

            }));


        }
    }

    private void OnMouseDown()
    {

        //infomanager.UpdateIconVisibility(transform.name);
        weather.Location = city.text;
        StartCoroutine(GetFest(weather.Location, result =>
        {
            FinalOutput.color = new Color32(0, 0, 0, 255);
            FinalOutput.fontSize = 15.0f;
            FinalOutput.text = result.AI;
            FinalOutput.gameObject.SetActive(true);

        }));


    }

    IEnumerator GetFest(string id, System.Action<WeatherHTTP> callback = null)
    {
        using (UnityWebRequest request = UnityWebRequest.Get("https://us-east-1.aws.webhooks.mongodb-realm.com/api/client/v2.0/app/destin_info-uhypn/service/Info_Center/incoming_webhook/get_Weather?Location=" + id))
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
                    callback.Invoke(WeatherHTTP.Parse(request.downloadHandler.text));
                }
            }
        }
    }

}