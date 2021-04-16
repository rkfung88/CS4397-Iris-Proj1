using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BackButton : MonoBehaviour
{
    private InfoManager infomanager;
    public GameObject map;
    public TextMeshPro FinalOutput;
    public List<GameObject> pins;

    // Start is called before the first frame update
    void Start()
    {
        infomanager = FindObjectOfType<InfoManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if((Input.touchCount > 0) && (Input.GetTouch(0).phase == TouchPhase.Ended))
        {
            Ray raycast = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
            RaycastHit raycastHit;
            if (Physics.Raycast(raycast, out raycastHit))
            {
                Debug.Log("1");
                //if (raycastHit.collider.name == "Map")
                //{
                //    Debug.Log("Map clicked");
                //}

                //OR with Tag

                if (raycastHit.collider.CompareTag("Back"))
                {
                    Debug.Log("Back");
                    OnMouseDown();
                }
            }
            //if (infomanager.uistate == uiStates.allShowing)
            //{
            //    infomanager.UpdateVisibility(false);
            //}
            //else if (infomanager.uistate == uiStates.twoShowing)
            //{
            //    infomanager.UpdateVisibility(true);
            //    FinalOutput.text = " ";
            //    map.SetActive(true);
            //    foreach (var pin in pins)
            //    {
            //        pin.SetActive(true);
            //    }

            //}

        }
        
    }

    private void OnMouseDown()
    {
        if (infomanager.uistate == uiStates.allShowing)
        {
            infomanager.UpdateVisibility(false);
        }
        else if (infomanager.uistate == uiStates.twoShowing)
        {
            infomanager.UpdateVisibility(true);
            FinalOutput.text = " ";
            map.SetActive(true);
            foreach (var pin in pins)
            {
                pin.SetActive(true);
            }

        }
    }
}
