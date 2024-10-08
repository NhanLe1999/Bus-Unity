using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Logic : Singleton<Logic>
{
    public TrackingLogic TrackingLogic { get; private set; }

    public void Init()
    {
        TrackingLogic = new TrackingLogic();
        TrackingLogic.Init();
    }

}
