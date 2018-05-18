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
    {
        canWalk = true;
    }

    private void OnTriggerExit()
    {
        canWalk = false;
    }

    // Update is called once per frame
    void Update () {
		
	}
}
