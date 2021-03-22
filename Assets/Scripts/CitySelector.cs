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
            infomanager.UpdateName(transform.name);
            infomanager.UpdateVisibility(true);
        }
    }
    private void OnMouseDown()
    {
        infomanager.UpdateName(transform.name);
        infomanager.UpdateVisibility(true);
        FinalOutput.text = " ";
    }
}
