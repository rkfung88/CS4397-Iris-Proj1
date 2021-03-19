using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InfoManager : MonoBehaviour
{
    public GameObject info;
    public TextMeshPro city;
    // Start is called before the first frame update
    void Start()
    {
        //ToggleAppear();
        info.SetActive(false);
    }

    public void UpdateName(string name)
    {
        city.text = name;
    }

    public void UpdateVisibility(bool visible)
    {
        info.SetActive(visible);
    }
    //public void ToggleAppear()
    //{
    //    Renderer rend = gameObject.GetComponent<Renderer>();

    //    if (rend.enabled)
    //    {
    //        rend.enabled = false;
    //    }
    //    else
    //    {
    //        rend.enabled = true;
    //    }
    //}
}
