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
                Vector3 wp = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);
                Vector2 touchPos = new Vector2(wp.x, wp.y);
                if (GetComponent<Collider2D>().OverlapPoint(wp))
                {
                    //infomanager.UpdateName(transform.name);
                    //infomanager.UpdateVisibility(true);
                    //FinalOutput.text = " ";
                    Ray raycast = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
                    RaycastHit raycastHit;
                    if (Physics.Raycast(raycast, out raycastHit))
                    {
                        Debug.Log("010");
                        //    //if (raycastHit.collider.name == "Map")
                        //    //{
                        //    //    Debug.Log("Map clicked");
                        //    //}

                        //    //OR with Tag

                        if (raycastHit.collider.CompareTag("Tokyo"))
                        {
                            Debug.Log("Tokyo");
                            infomanager.UpdateName(transform.name);
                            infomanager.UpdateVisibility(true);
                            FinalOutput.text = " ";
                        }
                    }
                }
            }
        }
    }
    private void OnMouseDown()
    {
        infomanager.UpdateName(transform.name);
        infomanager.UpdateVisibility(true);
        FinalOutput.text = " ";
    }
}
