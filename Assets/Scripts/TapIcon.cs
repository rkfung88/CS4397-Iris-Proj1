using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TapIcon : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if ((Input.touchCount > 0) && (Input.GetTouch(0).phase == TouchPhase.Began))
        {
            Ray raycast = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
            RaycastHit raycastHit;
            if (Physics.Raycast(raycast, out raycastHit))
            {
                Debug.Log("Something Touch");
                //if (raycastHit.collider.name == "Map")
                //{
                //    Debug.Log("Map clicked");
                //}

                //OR with Tag

                if (raycastHit.collider.CompareTag("Map"))
                {
                    Debug.Log("Map");
                }
            }
        }
    }
}
