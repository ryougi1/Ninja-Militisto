using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class RunningManager : MonoBehaviour
{
    public Rigidbody Body;

    public Running left;
    public Running right;

    public bool canWalk;
    public bool isJumping = false;
    uint counter = 0;
    //private float maxVel = ;
    //private float minVel = 
  

    // Update is called once per frame
    void FixedUpdate()
    {
        var devicer = SteamVR_Controller.Input((int)right.controller.index);
        var devicel = SteamVR_Controller.Input((int)left.controller.index);


        canWalk = left.canWalk || right.canWalk;

        if (canWalk && !isJumping)
        {
            if (left.canWalk)
            {
                Body.useGravity = false;
                Body.isKinematic = true;

                Body.transform.position += new Vector3(2f*(left.prevPos.x - left.transform.localPosition.x), 0f, 2f*(left.prevPos.z - left.transform.localPosition.z));
                //Body.AddForce(new Vector3(3f * (left.prevPos.x - left.transform.localPosition.x), 0f, 3f * (left.prevPos.z - left.transform.localPosition.z)), ForceMode.Impulse);
                //Body.MovePosition(transform.position + new Vector3((left.prevPos.x - left.transform.localPosition.x), 0f, (left.prevPos.z - left.transform.localPosition.z)));
            } 
            if (right.canWalk)
            {
                Body.useGravity = false;
                Body.isKinematic = true;

                Body.transform.position += new Vector3(2f*(right.prevPos.x - right.transform.localPosition.x), 0f, 2f*(right.prevPos.z - right.transform.localPosition.z));
                //Body.AddForce(new Vector3(3f * (right.prevPos.x - right.transform.localPosition.x), 0f, 3f * (right.prevPos.z - right.transform.localPosition.z)), ForceMode.Impulse);
                //Body.MovePosition(transform.position + new Vector3((right.prevPos.x - right.transform.localPosition.x), 0f, (right.prevPos.z - right.transform.localPosition.z)));
            }

        }
        else
        {
            Body.useGravity = true;
            Body.isKinematic = false;
        }

        if ((devicer.GetPressUp(SteamVR_Controller.ButtonMask.Grip) && right.canWalk) && isJumping == false)
        {

            isJumping = true;
            Body.useGravity = true;
            Body.isKinematic = false;
            float v3x = 70 * (right.prevPos.x - right.controller.transform.localPosition.x);
            float v3z = 70 * (right.prevPos.z - right.controller.transform.localPosition.z);
            Debug.LogFormat("v3x = {0}", v3x);
            Debug.LogFormat("v3z = {0}", v3z);
            if(Mathf.Abs(v3x) > 6)
            {
                if(v3x < 0)
                    v3x = -6f;
                if (v3x > 0)
                    v3x = 6f;
            }
            if (Mathf.Abs(v3z) > 6)
            {
                if (v3z < 0)
                    v3z = -6f;
                if (v3z > 0)
                    v3z = 6f;
            }
            Body.velocity = new Vector3(v3x, 4f, v3z);
            //Debug.LogFormat("Body vel: = {0}", Body.velocity);
            //Body.AddForce(new Vector3(0.0f, 2.0f, 0.0f) * 2f, ForceMode.Impulse);
        }
        if ((devicel.GetPressUp(SteamVR_Controller.ButtonMask.Grip) && left.canWalk) && isJumping == false)
        {
 
            isJumping = true;
            Body.useGravity = true;
            Body.isKinematic = false;
            float v3x = 70 * (left.prevPos.x - left.controller.transform.localPosition.x);
            float v3z = 70 * (left.prevPos.z - left.controller.transform.localPosition.z);
            Debug.LogFormat("v3x = {0}", v3x);
            Debug.LogFormat("v3z = {0}", v3z);
            if (Mathf.Abs(v3x) > 6)
            {
                if (v3x < 0)
                    v3x = -6f;
                if (v3x > 0)
                    v3x = 6f;
            }
            if (Mathf.Abs(v3z) > 6)
            {
                if (v3z < 0)
                    v3z = -6f;
                if (v3z > 0)
                    v3z = 6f;
            }
            Body.velocity = new Vector3(v3x, 4f, v3z);
            //Debug.LogFormat("Body vel: = {0}", Body.velocity);
            //Body.AddForce(new Vector3(0.0f, 2.0f, 0.0f) * 2f, ForceMode.Impulse);
        }

        left.prevPos = left.controller.transform.localPosition;
        right.prevPos = right.controller.transform.localPosition;


        if (isJumping && ++counter > 10) {
            counter = 0;
            isJumping = false;
        }

    }
}
