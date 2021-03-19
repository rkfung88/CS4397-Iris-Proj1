using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CitySelector : MonoBehaviour
{
    private InfoManager infomanager;

    private void Start()
    {
        infomanager = FindObjectOfType<InfoManager>();
    }
    private void OnMouseDown()
    {
        infomanager.UpdateName(transform.name);
        infomanager.UpdateVisibility(true);
    }
}
