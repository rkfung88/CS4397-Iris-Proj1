using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RestHTTP
{
    public string _id;
    public string Location;
    public string Cuisine;
    public string Foods;

    public string Stringify()
    {
        return JsonUtility.ToJson(this);
    }

    public static RestHTTP Parse(string json)
    {
        return JsonUtility.FromJson<RestHTTP>(json);
    }
}
