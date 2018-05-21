using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ListenSwap : MonoBehaviour {
    public SteamVR_TrackedObject leftHandController;
    public SteamVR_TrackedObject rightHandController;

    public GameObject modelHandLeft;
    public GameObject modelHandRight;
    //public GameObject modelFootLeft;
    //public GameObject modelFootRight;

    private bool isLeftFoot, isRightFoot;
    //float lockPos = 0;

    // Update is called once per frame
    void Update () {
        if (SteamVR_Controller.Input((int)leftHandController.index).GetTouchDown(SteamVR_Controller.ButtonMask.Trigger))
        {
            leftHandController.GetComponent<Pull>().enabled = !leftHandController.GetComponent<Pull>().enabled;
            leftHandController.GetComponent<Running>().enabled = !leftHandController.GetComponent<Running>().enabled;

            //modelHandLeft.SetActive(!modelHandLeft.activeSelf);
            //modelFootLeft.SetActive(!modelFootLeft.activeSelf);

            isLeftFoot = !isLeftFoot;
            if(isLeftFoot)
            {
                modelHandLeft.layer = LayerMask.NameToLayer("ControllerFoot");
                modelHandLeft.transform.parent.gameObject.layer = LayerMask.NameToLayer("ControllerFoot");
            } else
            {
                modelHandLeft.layer = LayerMask.NameToLayer("ControllerHand");
                modelHandLeft.transform.parent.gameObject.layer = LayerMask.NameToLayer("ControllerHand");
            }
            
            //modelHandLeft.transform.position += new Vector3(0f, -.3f, 0f);
            //modelHandLeft.transform.rotation = Quaternion.Euler(lockPos, lockPos, lockPos);

            //left.transform.rotation = Quaternion.Euler(0.0f, 0.0f, 0.0f);
            //left.GetComponent<Rigidbody>().freezeRotation = true;
        }
        if (SteamVR_Controller.Input((int)rightHandController.index).GetTouchDown(SteamVR_Controller.ButtonMask.Trigger))
        {
            rightHandController.GetComponent<Pull>().enabled = !rightHandController.GetComponent<Pull>().enabled;
            rightHandController.GetComponent<Running>().enabled = !rightHandController.GetComponent<Running>().enabled;

            isRightFoot = !isRightFoot;
            if (isRightFoot)
            {
                modelHandRight.layer = LayerMask.NameToLayer("ControllerFoot");
                modelHandRight.transform.parent.gameObject.layer = LayerMask.NameToLayer("ControllerFoot");
            }
            else
            {
                modelHandRight.layer = LayerMask.NameToLayer("ControllerHand");
                modelHandRight.transform.parent.gameObject.layer = LayerMask.NameToLayer("ControllerHand");
            }
            //modelHandRight.SetActive(!modelHandRight.activeSelf);
            //modelFootRight.SetActive(!modelFootRight.activeSelf);

            //modelHandRight.transform.position += new Vector3(0f, -.3f, 0f);
            //modelHandRight.transform.rotation = Quaternion.Euler(lockPos, lockPos, lockPos);

            //right.transform.rotation = Quaternion.Euler(0.0f, 0.0f, 0.0f);
            //right.GetComponent<Rigidbody>().freezeRotation = true;

        }

        if (isLeftFoot)
        {
            //modelHandLeft.transform.position += new Vector3(0f, -.3f, 0f);

            modelHandLeft.transform.position = leftHandController.transform.position + new Vector3(0f, -.7f, 0f);
          

        } else
        {
            modelHandLeft.transform.position = leftHandController.transform.position;
        }
        if (isRightFoot)
        {
            //modelHandRight.transform.position += new Vector3(0f, -.3f, 0f);

            modelHandRight.transform.position = rightHandController.transform.position + new Vector3(0f, -.7f, 0f);

        } else
        {
            modelHandRight.transform.position = rightHandController.transform.position;
        }
    }
    
    void FixedUpdate()
    {
        
    }
}
