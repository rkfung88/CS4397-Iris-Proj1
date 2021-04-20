using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomsHTTP
{
    public string _id;
    public string Location;
    public string Customs;

    public string Stringify()
    {
        return JsonUtility.ToJson(this);
    }

    public static CustomsHTTP Parse(string json)
    {
        return JsonUtility.FromJson<CustomsHTTP>(json);
    }
}
