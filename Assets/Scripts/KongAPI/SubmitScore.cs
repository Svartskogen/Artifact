using UnityEngine;
using System.Runtime.InteropServices;

public class SubmitScore : MonoBehaviour {

    [DllImport("__Internal")]
    private static extern void SubmitKongStat(string StatName, int StatValue);

    public int LevelsBeat = 1;


    // use this to submit
    //Change YOURSTATNAME, to the statistic you wish to use, and LevelsBeat to the value


    //SubmitKongStat("YOURSTATNAME", LevelsBeat);
}
