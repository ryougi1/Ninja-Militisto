using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ListenSwap : MonoBehaviour {
    public SteamVR_TrackedObject leftHandController;
    public SteamVR_TrackedObject rightHandController;

    public GameObject left;
    public GameObject right;


    // Update is called once per frame
    void Update () {
        if (SteamVR_Controller.Input((int)leftHandController.index).GetTouchDown(SteamVR_Controller.ButtonMask.Trigger))
        {
            left.GetComponent<Pull>().enabled = !left.GetComponent<Pull>().enabled;
            left.GetComponent<Running>().enabled = !left.GetComponent<Running>().enabled;
        }
        if (SteamVR_Controller.Input((int)rightHandController.index).GetTouchDown(SteamVR_Controller.ButtonMask.Trigger))
        {
            right.GetComponent<Pull>().enabled = !right.GetComponent<Pull>().enabled;
            right.GetComponent<Running>().enabled = !right.GetComponent<Running>().enabled;
        }
    }
}
