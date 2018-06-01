using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Running : MonoBehaviour {
    public Vector3 prevPos;
    public SteamVR_TrackedObject controller;
    // Use this for initialization
    public bool canWalk;

    void Start () {
        prevPos = controller.transform.localPosition;
    }

    private void OnTriggerEnter(Collider obj)
    //void OnCollisionEnter(Collision col) 
    {
        if (controller.GetComponent<Running>().enabled == false)
            return;
        canWalk = true;
    }

    private void OnTriggerExit()
    //void OnCollisionExit(Collision col) 
    {
        canWalk = false;
    }

    // Update is called once per frame
    void Update () {
        
	}
}
