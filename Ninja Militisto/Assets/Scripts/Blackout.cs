using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Blackout : MonoBehaviour {
    //public Image image;
    //public Canvas canvas;
    //public GameObject go;

    // Update is called once per frame
    private void OnTriggerEnter(Collider obj)
    {
        Debug.Log("IN");
        //image.color = new Color(0, 0, 0, 255);
        //canvas.transform.position = go.transform.position;
        SteamVR_Fade.Start(Color.black, 0);
        //SteamVR_Fade.View(Color.black, 0);
    }

    private void OnTriggerExit()
    {
        Debug.Log("OUT");
        //image.color = new Color(0, 0, 0, 0);
        SteamVR_Fade.Start(Color.clear, 0);
        //SteamVR_Fade.View(Color.clear, 0);
    }
}
