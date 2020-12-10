using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointManager : MonoBehaviour {

    public static bool checkpointActive;

    public void On ()
    {
        checkpointActive = true;
        Main.checkpointLv1Reached = false;
        Main.checkpointLv2Reached = false;
        LV3.checkpointLv3Reached = false;
    }

    public void Off ()
    {
        checkpointActive = false;
        Main.checkpointLv1Reached = false;
        Main.checkpointLv2Reached = false;
        LV3.checkpointLv3Reached = false;
    }
}
