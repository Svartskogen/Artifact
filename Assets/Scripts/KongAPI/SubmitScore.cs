using UnityEngine;
using System.Runtime.InteropServices;
using System;

[Obsolete("Deprecated, not releasing to Kongregate anymore", false)]
public class SubmitScore : MonoBehaviour 
{
    [DllImport("__Internal")]
    private static extern void SubmitKongStat(string StatName, int StatValue);
}
