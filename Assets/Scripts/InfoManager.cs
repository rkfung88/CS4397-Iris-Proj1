using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public enum uiStates { allHidden, allShowing, twoShowing }

public class InfoManager : MonoBehaviour
{
    public GameObject info;
    public TextMeshPro city;
    public GameObject uiHolder;
    public uiStates uistate;
    // Start is called before the first frame update
    void Start()
    {
        //ToggleAppear();
        UpdateVisibility(false);
        uistate = uiStates.allHidden;
    }

    public void UpdateName(string name)
    {
        Debug.Log(name + "Choosen");
        city.text = name;
    }


    public void UpdateVisibility(bool visible)
    {
        uiHolder.SetActive(visible);
        foreach (Transform t in info.transform)
        {
            t.gameObject.SetActive(true);
        }
        if (visible)
        {
            uistate = uiStates.allShowing;
        }
        else
        {
            uistate = uiStates.allHidden;
        }    
        
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
        uistate = uiStates.twoShowing;
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
