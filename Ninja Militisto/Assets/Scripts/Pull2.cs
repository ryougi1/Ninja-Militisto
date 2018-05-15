using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pull2 : MonoBehaviour
{

    public GameObject Body;
    public SteamVR_TrackedObject controller;
    public Vector3 prevPos;
    public bool canGrip;

    // Use this for initialization
    void Start()
    {
        prevPos = controller.transform.localPosition;
    }

    // Update is called once per frame
    void Update()
    {
        var device = SteamVR_Controller.Input((int)controller.index);
        if (canGrip && device.GetTouch(SteamVR_Controller.ButtonMask.Trigger))
        {
            Body.transform.position += (prevPos - controller.transform.localPosition);
        }

        prevPos = controller.transform.localPosition;
    }

    void OnTriggerEnter()
    {
        canGrip = true;
    }

    void OnTriggerExit()
    {
        canGrip = false;
    }
}
