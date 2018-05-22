using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ListenSwap : MonoBehaviour {
    public SteamVR_TrackedObject leftHandController;
    public SteamVR_TrackedObject rightHandController;

    public GameObject modelHandLeft;
    public GameObject modelHandRight;


    private bool isLeftFoot, isRightFoot;

    // Update is called once per frame
    void Update () {
        if (SteamVR_Controller.Input((int)leftHandController.index).GetTouchDown(SteamVR_Controller.ButtonMask.Trigger))
        {
            leftHandController.GetComponent<Pull>().enabled = !leftHandController.GetComponent<Pull>().enabled;
            leftHandController.GetComponent<Running>().enabled = !leftHandController.GetComponent<Running>().enabled;

            //modelHandLeft.GetComponent<Collider>().isTrigger = !modelHandLeft.GetComponent<Collider>().isTrigger;
            
            isLeftFoot = !isLeftFoot;
            /*
            if (isLeftFoot)
            {
                modelHandLeft.layer = LayerMask.NameToLayer("ControllerFoot");
                modelHandLeft.transform.parent.gameObject.layer = LayerMask.NameToLayer("ControllerFoot");
            } else
            {
                modelHandLeft.layer = LayerMask.NameToLayer("ControllerHand");
                modelHandLeft.transform.parent.gameObject.layer = LayerMask.NameToLayer("ControllerHand");
            }
            */
            
        }
        if (SteamVR_Controller.Input((int)rightHandController.index).GetTouchDown(SteamVR_Controller.ButtonMask.Trigger))
        {
            rightHandController.GetComponent<Pull>().enabled = !rightHandController.GetComponent<Pull>().enabled;
            rightHandController.GetComponent<Running>().enabled = !rightHandController.GetComponent<Running>().enabled;

            //modelHandRight.GetComponent<Collider>().isTrigger = !modelHandRight.GetComponent<Collider>().isTrigger;

            
            isRightFoot = !isRightFoot;
            /*
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
            */
            
        }

        if (isLeftFoot)
        {
            modelHandLeft.transform.position = leftHandController.transform.position + new Vector3(0f, -.7f, 0f);

        } else
        {
            modelHandLeft.transform.position = leftHandController.transform.position;
        }
        if (isRightFoot)
        {
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
