using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PDHTTP
{
    public string _id;
    public string Location;
    public string PD;

    public string Stringify()
    {
        return JsonUtility.ToJson(this);
    }

    public static PDHTTP Parse(string json)
    {
        return JsonUtility.FromJson<PDHTTP>(json);
    }
}
