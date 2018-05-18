using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunningManager : MonoBehaviour
{
    public Rigidbody Body;

    public Running left;
    public Running right;

    // Update is called once per frame
    void FixedUpdate()
    {
        var devicer = SteamVR_Controller.Input((int)right.controller.index);
        var devicel = SteamVR_Controller.Input((int)left.controller.index);


        bool canWalk = left.canWalk || right.canWalk;

        if (canWalk)
        {
            if (left.canWalk)
            {
                Body.useGravity = false;
                Body.isKinematic = true;
                //left.prevPos.x = left.prevPos.x - left.transform.localPosition.x;
                //left.prevPos.z = left.prevPos.z - left.transform.localPosition.z;
               // Body.transform.position += left.prevPos;
                Body.transform.position += (left.prevPos - left.transform.localPosition);
            }


            if (right.canWalk)
            {
                Body.useGravity = false;
                Body.isKinematic = true;
                //right.prevPos.x = right.prevPos.x - right.transform.localPosition.x;
                //right.prevPos.z = right.prevPos.z - right.transform.localPosition.z;
               // Body.transform.position += right.prevPos;
                Body.transform.position += (right.prevPos - right.transform.localPosition);
            }

        }
        else
        {
            Body.useGravity = true;
            Body.isKinematic = false;

            //Body.velocity = (left.prevPos - left.transform.localPosition) / Time.deltaTime * 0.35f; //??
            //Body.velocity = (right.prevPos - right.transform.localPosition) / Time.deltaTime * 0.35f;
        }

        left.prevPos = left.controller.transform.localPosition;
        right.prevPos = right.controller.transform.localPosition;
    }
}
