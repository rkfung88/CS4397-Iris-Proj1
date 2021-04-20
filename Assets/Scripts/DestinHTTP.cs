using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestinHTTP
{
    public string _id;
    public string Location;
    public string Known_For;
    public string Places;

    public string Stringify()
    {
        return JsonUtility.ToJson(this);
    }

    public static DestinHTTP Parse(string json)
    {
        return JsonUtility.FromJson<DestinHTTP>(json);
    }
}
