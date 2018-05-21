using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunningManager : MonoBehaviour
{
    public Rigidbody Body;

    public Running left;
    public Running right;

    public bool canWalk;
    public bool doIt = false;

    // Update is called once per frame
    void FixedUpdate()
    {
        var devicer = SteamVR_Controller.Input((int)right.controller.index);
        var devicel = SteamVR_Controller.Input((int)left.controller.index);


        canWalk = left.canWalk || right.canWalk;

        if (canWalk)
        {
            if (left.canWalk)
            {
                Body.useGravity = false;
                Body.isKinematic = true;
                //left.prevPos.x = left.prevPos.x - left.transform.localPosition.x;
                //left.prevPos.z = left.prevPos.z - left.transform.localPosition.z;
               //Body.transform.position += left.prevPos;
                Body.transform.position += new Vector3(1.5f*(left.prevPos.x - left.transform.localPosition.x), 0f, 1.5f*(left.prevPos.z - left.transform.localPosition.z));
            }


            if (right.canWalk)
            {
                Body.useGravity = false;
                Body.isKinematic = true;
                //right.prevPos.x = right.prevPos.x - right.transform.localPosition.x;
                //right.prevPos.z = right.prevPos.z - right.transform.localPosition.z;
                //Body.transform.position += right.prevPos;

                //Body.transform.position += (right.prevPos - right.transform.localPosition);'
                Body.transform.position += new Vector3(1.5f*(right.prevPos.x - right.transform.localPosition.x), 0f, 1.5f*(right.prevPos.z - right.transform.localPosition.z));
            }

        }
        else
        {
            Body.useGravity = true;
            Body.isKinematic = false;

            
        }

        if ((devicer.GetPressDown(SteamVR_Controller.ButtonMask.Grip) || devicel.GetPressDown(SteamVR_Controller.ButtonMask.Grip)) && canWalk)
        {
            //Body.velocity = (left.prevPos - left.transform.localPosition) / Time.deltaTime * 0.35f;
            //Body.velocity = (right.prevPos - right.transform.localPosition) / Time.deltaTime * 0.35f;
            //Body.velocity += new Vector3(0f, 10f, 0f);
            //Body.AddForce(Vector3.up * 8f);

            //Body.velocity = new Vector3(70*(left.prevPos.x - left.controller.transform.localPosition.x), 10f, 70*(left.prevPos.z - left.controller.transform.localPosition.z));
            Body.AddForce(0, 10f, 0, ForceMode.Impulse);
        }
        doIt = !doIt;
        if (doIt)
        {
            left.prevPos = left.controller.transform.localPosition;
            right.prevPos = right.controller.transform.localPosition;
        }
    }
}
