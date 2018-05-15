using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GripManager : MonoBehaviour {
    public Rigidbody Body;

    public Pull left;
    public Pull right;

    // Update is called once per frame
    void FixedUpdate()
    {
        var ldevice = SteamVR_Controller.Input((int)left.controller.index);
        var rdevice = SteamVR_Controller.Input((int)right.controller.index);

        bool isGripped = left.canGrip || right.canGrip;

        if (isGripped)
        {
            if (left.canGrip && ldevice.GetTouch(SteamVR_Controller.ButtonMask.Grip))
            {
                Body.useGravity = false;
                Body.isKinematic = true;
                Body.transform.position += (left.prevPos - left.transform.localPosition);

            }
            else if (left.canGrip && ldevice.GetTouchUp(SteamVR_Controller.ButtonMask.Grip))
            {
                Body.useGravity = true;
                Body.isKinematic = false;
                Body.velocity = (left.prevPos - left.transform.localPosition) / Time.deltaTime;
            }

            if (right.canGrip && rdevice.GetTouch(SteamVR_Controller.ButtonMask.Grip))
            {
                Body.useGravity = false;
                Body.isKinematic = true;
                Body.transform.position += (right.prevPos - right.transform.localPosition);

            }
            else if (right.canGrip && rdevice.GetTouchUp(SteamVR_Controller.ButtonMask.Grip))
            {
                Body.useGravity = true;
                Body.isKinematic = false;
                Body.velocity = (right.prevPos - right.transform.localPosition) / Time.deltaTime;
            }
        }
        
        else
        {
            Body.useGravity = true;
            Body.isKinematic = false;
        }

        left.prevPos = left.transform.localPosition;
        right.prevPos = right.transform.localPosition;

    }
}
