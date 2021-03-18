using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleVisibility : MonoBehaviour
{
    public GameObject info;
    // Start is called before the first frame update
    void Start()
    {
        //ToggleAppear();
        info.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
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
