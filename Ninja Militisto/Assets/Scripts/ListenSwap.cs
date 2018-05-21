using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ListenSwap : MonoBehaviour {
    public SteamVR_TrackedObject leftHandController;
    public SteamVR_TrackedObject rightHandController;

    public GameObject left;
    public GameObject right;

    public GameObject modelHandLeft;
    public GameObject modelHandRight;
    //public GameObject modelFootLeft;
    //public GameObject modelFootRight;

    //private bool isLeftFoot, isRightFoot;
    //float lockPos = 0;

    // Update is called once per frame
    void Update () {
        if (SteamVR_Controller.Input((int)leftHandController.index).GetTouchDown(SteamVR_Controller.ButtonMask.Trigger))
        {
            left.GetComponent<Pull>().enabled = !left.GetComponent<Pull>().enabled;
            left.GetComponent<Running>().enabled = !left.GetComponent<Running>().enabled;

            //modelHandLeft.SetActive(!modelHandLeft.activeSelf);
            //modelFootLeft.SetActive(!modelFootLeft.activeSelf);

            modelHandLeft.transform.position += new Vector3(0f, -.3f, 0f);
            //modelHandLeft.transform.rotation = Quaternion.Euler(lockPos, lockPos, lockPos);

            //left.transform.rotation = Quaternion.Euler(0.0f, 0.0f, 0.0f);
            //left.GetComponent<Rigidbody>().freezeRotation = true;
        }
        if (SteamVR_Controller.Input((int)rightHandController.index).GetTouchDown(SteamVR_Controller.ButtonMask.Trigger))
        {
            right.GetComponent<Pull>().enabled = !right.GetComponent<Pull>().enabled;
            right.GetComponent<Running>().enabled = !right.GetComponent<Running>().enabled;


            //modelHandRight.SetActive(!modelHandRight.activeSelf);
            //modelFootRight.SetActive(!modelFootRight.activeSelf);

            modelHandRight.transform.position += new Vector3(0f, -.3f, 0f);
            //modelHandRight.transform.rotation = Quaternion.Euler(lockPos, lockPos, lockPos);

            //right.transform.rotation = Quaternion.Euler(0.0f, 0.0f, 0.0f);
            //right.GetComponent<Rigidbody>().freezeRotation = true;

        }
    }
    /**
    void FixedUpdate()
    {
        if (isLeftFoot)
        {
            modelHandLeft.transform.position += new Vector3(0f, -.3f, 0f);
            
           /* THIS
           *  maybe this was the correct way but it should be:
           *  modelHandLeft.transfrom.position = left.transform.position + new Vector3(0f, -.3f, 0f);
           */
       // }
        //if (isRightFoot)
       // {
           // modelHandRight.transform.position += new Vector3(0f, -.3f, 0f);
        //}
    //}
    
}
