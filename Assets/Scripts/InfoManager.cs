using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InfoManager : MonoBehaviour
{
    public GameObject info;
    public TextMeshPro city;
    public GameObject uiHolder;
    // Start is called before the first frame update
    void Start()
    {
        //ToggleAppear();
        UpdateVisibility(false);
    }

    public void UpdateName(string name)
    {
        city.text = name;
    }

    public void UpdateVisibility(bool visible)
    {
        uiHolder.SetActive(visible);
    }

    public void UpdateIconVisibility(string iconname)
    {
        foreach(Transform t in info.transform)
        {
            if (t.name == iconname)
            {
                t.gameObject.SetActive(true);
            }
            else
            {
                t.gameObject.SetActive(false);
            }
        }
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
