using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BackButton : MonoBehaviour
{
    private InfoManager infomanager;
    public GameObject map;
    public TextMeshPro FinalOutput;

    // Start is called before the first frame update
    void Start()
    {
        infomanager = FindObjectOfType<InfoManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
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
            //map.SetActive(true);
        }
    }
}
