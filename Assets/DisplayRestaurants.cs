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
    public TextMeshPro SelectedInfo;
    public TextMeshPro InfoIconText;

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
            if (Input.touchCount == 1)
            {

                Ray raycast = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
                RaycastHit raycastHit;
                if (Physics.Raycast(raycast, out raycastHit))
                {

                    if (raycastHit.collider.gameObject.GetComponent<DisplayRestaurants>())
                    {
                        Debug.Log($"The restaurant button was hit while {infomanager.city.text} was selected ");
                        onClickOrTap();
                    }

                }
            }
        }
    }

    private void onClickOrTap()
    {
        //infomanager.UpdateIconVisibility(transform.name);
        map.SetActive(true);

        foreach (var pin in pins)
        {
            pin.SetActive(false);
        }
        rest.Location = city.text;
        SelectedInfo.text = InfoIconText.text;
        StartCoroutine(GetRestaurants(rest.Location, result =>
        {
            FinalOutput.color = new Color32(0, 0, 0, 255);
            FinalOutput.fontSize = 5.5f;
            FinalOutput.text = result.Cuisine + "\n" + result.Foods + "\n" + result.Rest + "\n\n";
            FinalOutput.gameObject.SetActive(true);


        }));

    }

    private void OnMouseDown()
    {
        onClickOrTap();
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


