﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GripManager : MonoBehaviour {
    public Rigidbody Body;

    public Pull left;
    public Pull right;
    public bool grippedPressed;
    public bool canGrip;

    // Update is called once per frame
    void FixedUpdate()
    {
        var devicer = SteamVR_Controller.Input((int)right.controller.index);
        var devicel = SteamVR_Controller.Input((int)left.controller.index);


        canGrip = left.canGrip || right.canGrip;
        grippedPressed = devicel.GetPress(SteamVR_Controller.ButtonMask.Grip) || devicer.GetPress(SteamVR_Controller.ButtonMask.Grip);
        if (canGrip)
        {
            if (left.canGrip && devicel.GetPress(SteamVR_Controller.ButtonMask.Grip)) 
            {
                Body.useGravity = false;
                Body.isKinematic = true;
                Body.MovePosition(transform.position + (left.prevPos - left.transform.localPosition));
            }


              if (right.canGrip && devicer.GetPress(SteamVR_Controller.ButtonMask.Grip))
            {
                Body.useGravity = false;
                Body.isKinematic = true;
                Body.MovePosition(transform.position + (right.prevPos - right.transform.localPosition));

            }

        }
        else
        {
            Body.useGravity = true;
            Body.isKinematic = false;
            
        }

        if (left.canGrip && devicel.GetPressUp(SteamVR_Controller.ButtonMask.Grip) && canGrip == false)
        {
            Body.useGravity = true;
            Body.isKinematic = false;
            
            Body.velocity = ((left.prevPos - left.transform.localPosition) / Time.deltaTime) * 0.1f;
        }
        if (right.canGrip && devicer.GetPressUp(SteamVR_Controller.ButtonMask.Grip) && canGrip == false)
        {
            Body.useGravity = true;
            Body.isKinematic = false;
            Body.velocity = ((right.prevPos - right.transform.localPosition) / Time.deltaTime) * 0.1f;


        }
        left.prevPos = left.controller.transform.localPosition;
        right.prevPos = right.controller.transform.localPosition;
    }
}
