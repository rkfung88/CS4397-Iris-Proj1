using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LangHTTP
{
    public string _id;
    public string Location;
    public string Language;

    public string Stringify()
    {
        return JsonUtility.ToJson(this);
    }

    public static LangHTTP Parse(string json)
    {
        return JsonUtility.FromJson<LangHTTP>(json);
    }
}
