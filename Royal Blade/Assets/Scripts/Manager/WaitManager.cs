using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class WaitManager 
{
    private static Dictionary<float, WaitForSeconds> waits = new Dictionary<float, WaitForSeconds>();

    public static WaitForSeconds GetWait(float waitTime)
    {
        if (!waits.ContainsKey(waitTime))
        {
            waits.Add(waitTime, new WaitForSeconds(waitTime));
        }

        return waits[waitTime];
    }
}
