using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class WaitManager 
{
    private static Dictionary<float, WaitForSeconds> waits = new Dictionary<float, WaitForSeconds>();
    private static Dictionary<float, WaitForSecondsRealtime> realWaits = new Dictionary<float, WaitForSecondsRealtime>();

    public static WaitForSeconds GetWait(float waitTime)
    {
        if (!waits.ContainsKey(waitTime))
        {
            waits.Add(waitTime, new WaitForSeconds(waitTime));
        }

        return waits[waitTime];
    }
    public static WaitForSecondsRealtime GetRealWait(float waitTime)
    {
        if (!realWaits.ContainsKey(waitTime))
        {
            realWaits.Add(waitTime, new WaitForSecondsRealtime(waitTime));
        }

        return realWaits[waitTime];
    }
}
