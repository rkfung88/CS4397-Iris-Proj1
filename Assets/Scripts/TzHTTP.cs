using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TzHTTP
{
    public string _id;
    public string Location;
    public string Timezone;

    public string Stringify()
    {
        return JsonUtility.ToJson(this);
    }

    public static TzHTTP Parse(string json)
    {
        return JsonUtility.FromJson<TzHTTP>(json);
    }
}
