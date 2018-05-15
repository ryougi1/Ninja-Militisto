using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grip_temp : MonoBehaviour {
	public Rigidbody Body;
	public SteamVR_TrackedObject controller;
    public bool canGrip;
    public bool isGripping;

    [HideInInspector]
	public Vector3 prevPos;

	// Use this for initialization
	void Start () {
		prevPos = controller.transform.localPosition;
	}

    void Update()
    {
        var device = SteamVR_Controller.Input((int)controller.index);
        isGripping = device.GetTouch(SteamVR_Controller.ButtonMask.Trigger);
        if (canGrip && isGripping)
        {
            Body.useGravity = false;
            Body.isKinematic = true;
            Body.transform.position += (prevPos - controller.transform.localPosition);
        }
        else if (canGrip && device.GetTouchUp(SteamVR_Controller.ButtonMask.Trigger))
        {
            Body.useGravity = true;
            Body.isKinematic = false;
            Body.velocity = (prevPos - controller.transform.localPosition) / Time.deltaTime;
        }
        else
        {
            Body.useGravity = true;
            Body.isKinematic = false;
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

    // Update is called once per frame
    /**
	void FixedUpdate () {
		var device = SteamVR_Controller.Input ((int)controller.index);
		if (canGrip && device.GetTouch (SteamVR_Controller.ButtonMask.Grip)) {
			Body.useGravity = false;
			Body.isKinematic = true;
			Body.transform.position += (prevPos - controller.transform.localPosition);
	
		} else if (canGrip && device.GetTouchUp (SteamVR_Controller.ButtonMask.Grip)) {
			Body.useGravity = true;
			Body.isKinematic = false;
			Body.velocity = (prevPos - controller.transform.localPosition) / Time.deltaTime;
		} else {
			Body.useGravity = true;
			Body.isKinematic = false;
		}

		prevPos = controller.transform.localPosition;
	}
        **/
}
