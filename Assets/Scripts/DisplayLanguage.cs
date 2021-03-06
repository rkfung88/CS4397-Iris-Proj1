﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;
using TMPro;
using System.Text;
using UnityEngine.Networking;


public class DisplayLanguage : MonoBehaviour
{
    private InfoManager infomanager;
    private LangHTTP lang;
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
        lang = new LangHTTP();
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

                    if (raycastHit.collider.gameObject.GetComponent<DisplayLanguage>())
                    {
                        Debug.Log($"The language button was hit while {infomanager.city.text} was selected ");
                        onClickOrTap();
                    }

                }
            }
        }
    }

    private void onClickOrTap()
    {
        //infomanager.UpdateIconVisibility(transform.name);
        lang.Location = city.text;
        SelectedInfo.text = InfoIconText.text;
        StartCoroutine(GetLanguage(lang.Location, result =>
        {
            FinalOutput.alignment = TextAlignmentOptions.Center;
            FinalOutput.color = new Color32(0, 0, 0, 255);
            FinalOutput.fontSize = 20.0f;
            FinalOutput.text = result.Language;
            FinalOutput.gameObject.SetActive(true);

        }));

    }

    private void OnMouseDown()
    {
        onClickOrTap();
    }

    IEnumerator GetLanguage(string id, System.Action<LangHTTP> callback = null)
    {
        using (UnityWebRequest request = UnityWebRequest.Get("https://us-east-1.aws.webhooks.mongodb-realm.com/api/client/v2.0/app/destin_info-uhypn/service/Info_Center/incoming_webhook/get_Language?Location=" + id))
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
                    callback.Invoke(LangHTTP.Parse(request.downloadHandler.text));
                }
            }
        }
    }

}
