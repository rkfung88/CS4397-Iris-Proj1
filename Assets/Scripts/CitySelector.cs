using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CitySelector : MonoBehaviour
{
    private InfoManager infomanager;
    public TextMeshPro FinalOutput;

    private void Start()
    { 
        infomanager = FindObjectOfType<InfoManager>();
    }
    void Update()
    {
        if ((Input.touchCount > 0) && (Input.GetTouch(0).phase == TouchPhase.Began))
        {
            if (Input.touchCount == 1)
            {
                // = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);
                //Vector2 touchPos = new Vector2(wp.x, wp.y);
                //if (GetComponent<Collider2D>().OverlapPoint(wp))
                //{
                    //infomanager.UpdateName(transform.name);
                    //infomanager.UpdateVisibility(true);
                    //FinalOutput.text = " ";
                    Ray raycast = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
                    RaycastHit raycastHit;
                    if (Physics.Raycast(raycast, out raycastHit))
                    {
                     
                    if (raycastHit.collider.CompareTag("Pins"))
                    {
                        Debug.Log($"Collider {raycastHit.collider.name} was hit");
                       
                        handleTapOrClick(raycastHit.collider.name);
                    }
                    //    //if (raycastHit.collider.name == "Map")
                    //    //{
                    //    //    Debug.Log("Map clicked");
                    //    //}

                    //    //OR with Tag

                    //if (raycasthit.collider.comparetag("tokyo"))
                    //{
                    //    debug.log("tokyo");
                    //    infomanager.updatename(transform.name);
                    //    infomanager.updatevisibility(true);
                    //    finaloutput.text = " ";
                    //}
                }
                //}
            }
        }
    }
    private void OnMouseDown()
    {
        handleTapOrClick(transform.name);
    }

    private void handleTapOrClick(string name)
    {
        infomanager.UpdateName(name);
        infomanager.UpdateVisibility(true);
        FinalOutput.text = " ";
    }
}
