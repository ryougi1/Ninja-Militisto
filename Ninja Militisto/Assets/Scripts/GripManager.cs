using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GripManager : MonoBehaviour {
    public Rigidbody Body;

    public Pull left;
    public Pull right;
    public bool grippedPressed;

    // Update is called once per frame
    void FixedUpdate()
    {
        var devicer = SteamVR_Controller.Input((int)right.controller.index);
        var devicel = SteamVR_Controller.Input((int)left.controller.index);


        bool canGrip = left.canGrip || right.canGrip;
        grippedPressed = devicel.GetTouch(SteamVR_Controller.ButtonMask.Trigger);
        if (canGrip)
        {
            if (left.canGrip && grippedPressed) 
            {
                Body.useGravity = false;
                Body.isKinematic = true;
                Body.transform.position += (left.prevPos - left.transform.localPosition);
            }


            if (right.canGrip && devicer.GetTouch(SteamVR_Controller.ButtonMask.Trigger))
            {
                Body.useGravity = false;
                Body.isKinematic = true;
                Body.transform.position += (right.prevPos - right.transform.localPosition);
            }

        }
        else
        {
            Body.useGravity = true;
            Body.isKinematic = false;
            
        }

        if (devicel.GetTouchUp(SteamVR_Controller.ButtonMask.Trigger))
        {
            Body.useGravity = true;
            Body.isKinematic = false;
            Body.velocity = (left.prevPos - left.transform.localPosition) / Time.deltaTime * 0.35f;

        
        }
        if (devicer.GetTouchUp(SteamVR_Controller.ButtonMask.Trigger))
        {
            Body.useGravity = true;
            Body.isKinematic = false;
            Body.velocity = (right.prevPos - right.transform.localPosition) / Time.deltaTime * 0.35f;


        }
        left.prevPos = left.controller.transform.localPosition;
        right.prevPos = right.controller.transform.localPosition;
    }
}
