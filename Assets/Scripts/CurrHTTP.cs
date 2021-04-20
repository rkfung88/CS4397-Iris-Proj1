using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurrHTTP
{
    public string _id;
    public string Location;
    public string Currency;
   

    public string Stringify()
    {
        return JsonUtility.ToJson(this);
    }

    public static CurrHTTP Parse(string json)
    {
        return JsonUtility.FromJson<CurrHTTP>(json);
    }
}
