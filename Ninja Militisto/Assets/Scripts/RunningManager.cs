using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunningManager : MonoBehaviour
{
    public Rigidbody Body;

    public Running left;
    public Running right;

    public bool canWalk;
    public bool isJumping = false;
    uint counter = 0;

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

                //Body.transform.position += new Vector3(1.5f*(left.prevPos.x - left.transform.localPosition.x), 0f, 1.5f*(left.prevPos.z - left.transform.localPosition.z));
                Body.AddForce(new Vector3(3f * (left.prevPos.x - left.transform.localPosition.x), 0f, 3f * (left.prevPos.z - left.transform.localPosition.z)), ForceMode.Impulse);
                //Body.MovePosition(transform.position + new Vector3((left.prevPos.x - left.transform.localPosition.x), 0f, (left.prevPos.z - left.transform.localPosition.z)));
            }


            if (right.canWalk)
            {
                Body.useGravity = false;
                Body.isKinematic = true;

                //Body.transform.position += new Vector3(1.5f*(right.prevPos.x - right.transform.localPosition.x), 0f, 1.5f*(right.prevPos.z - right.transform.localPosition.z));
                Body.AddForce(new Vector3(3f * (right.prevPos.x - right.transform.localPosition.x), 0f, 3f * (right.prevPos.z - right.transform.localPosition.z)), ForceMode.Impulse);
                //Body.MovePosition(transform.position + new Vector3((right.prevPos.x - right.transform.localPosition.x), 0f, (right.prevPos.z - right.transform.localPosition.z)));
            }

        }
        else
        {
            Body.useGravity = true;
            Body.isKinematic = false;
        }

        if (((devicer.GetPressDown(SteamVR_Controller.ButtonMask.Grip) && right.canWalk) || (devicel.GetPressDown(SteamVR_Controller.ButtonMask.Grip) && left.canWalk)) && isJumping == false)
        {
            //Body.velocity = (left.prevPos - left.transform.localPosition) / Time.deltaTime * 0.35f;
            //Body.velocity = (right.prevPos - right.transform.localPosition) / Time.deltaTime * 0.35f;
            //Body.velocity += new Vector3(0f, 10f, 0f);
            //Body.AddForce(Vector3.up * 8f);

            isJumping = true;
            Body.useGravity = true;
            Body.isKinematic = false;

            //Body.velocity = new Vector3(70*(left.prevPos.x - left.controller.transform.localPosition.x), 10f, 70*(left.prevPos.z - left.controller.transform.localPosition.z));
            Body.AddForce(new Vector3(0.0f, 2.0f, 0.0f) * 2f, ForceMode.Impulse);
        }
        
        left.prevPos = left.controller.transform.localPosition;
        right.prevPos = right.controller.transform.localPosition;


        if (isJumping && ++counter > 10) {
            counter = 0;
            isJumping = false;
        }

    }
}
