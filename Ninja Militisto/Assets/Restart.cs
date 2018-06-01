using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Restart : MonoBehaviour {

    private void OnTriggerEnter(Collider obj)
    {
        SteamVR_Fade.Start(Color.clear, 0);
        SteamVR_Fade.Start(Color.white, 1f);
        RestartLevel();
    }

    public void RestartLevel()
    {
        Application.LoadLevel(Application.loadedLevel);
    }
}
