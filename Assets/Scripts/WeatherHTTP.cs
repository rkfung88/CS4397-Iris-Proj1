using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeatherHTTP
{
    public string _id;
    public string Location;
    public string Climate;
    public string BTV;
    public string AI;

    public string Stringify()
    {
        return JsonUtility.ToJson(this);
    }

    public static WeatherHTTP Parse(string json)
    {
        return JsonUtility.FromJson<WeatherHTTP>(json);
    }
}
