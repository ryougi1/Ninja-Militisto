using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class LevelManager : MonoBehaviour {

    public static LevelManager instance;
    public Animator animator;
    public Transform player;
    public Rigidbody body;
    public Restart r;
    private int levelToLoad;
    private bool isFirstLoad, walkedHasPlayed, grovelingPlayed, goodPlayed, disapointedPlayed;
    

    void Start()
    {
        isFirstLoad = true;
        walkedHasPlayed = false;
        grovelingPlayed = false;
        goodPlayed = false;
        disapointedPlayed = false;
        FindObjectOfType<AudioManager>().Play("BGM");
    }

        private void Update()
    {

      if (isFirstLoad)
        {
            FindObjectOfType<AudioManager>().Play("OnFirstLevelStart");
            isFirstLoad = false;
        }
        if (player.position.y <= -12)
        {
            if (disapointedPlayed == false)
            {
                disapointedPlayed = true;
                FindObjectOfType<AudioManager>().Play("Disapointed");
            }

            FadeToLevel(0);
        }
        if (player.position.z <= -75 && walkedHasPlayed == false)
        {
            walkedHasPlayed = true;
            FindObjectOfType<AudioManager>().Play("Walked");
        }
        if (player.position.z <= -115 && grovelingPlayed == false)
        {
            grovelingPlayed = true;
            FindObjectOfType<AudioManager>().Play("Grovel");
        }
        if (player.position.y >= 18 && goodPlayed == false)
        {
            goodPlayed = true;
            FindObjectOfType<AudioManager>().currentAudio.Stop();
            FindObjectOfType<AudioManager>().Play("Good");
            FindObjectOfType<AudioManager>().Play("BGM2");
            
        }
        if (Input.GetKeyDown("space"))
            r.RestartLevel();

        if (Input.GetKeyDown("1"))
        {
            SteamVR_Fade.Start(Color.black, 0);
            SteamVR_Fade.Start(Color.clear, 4.4f);
            player.position = new Vector3(-11.93f, -3.47f, -102.86f);
            body.velocity = new Vector3(0f, 0f, 0f);
        }
        if (Input.GetKeyDown("2"))
        {
            SteamVR_Fade.Start(Color.black, 0);
            SteamVR_Fade.Start(Color.clear, 4.4f);
            player.position = new Vector3(-11.66f, -3.24f, -117.5f);
            body.velocity = new Vector3(0f, 0f, 0f);
        }
        if (Input.GetKeyDown("3"))
        {
            SteamVR_Fade.Start(Color.black, 0);
            SteamVR_Fade.Start(Color.clear, 4.4f);
            player.position = new Vector3(-20.68f, 18.82f, -142.04f);
            body.velocity = new Vector3(0f, 0f, 0f);
        }
    }
    
    public void FadeToLevel(int levelIndex)
    {
        //levelToLoad = levelIndex;
        animator.SetBool("FO", true);
        animator.SetBool("FI", false);
        SteamVR_Fade.Start(Color.clear, 0);
        SteamVR_Fade.Start(Color.black, .4f);
    }

    public void OnFadeComplete()
    {
        //SceneManager.LoadScene(levelToLoad);
        animator.SetBool("FO", false);
        animator.SetBool("FI", true);
        SteamVR_Fade.Start(Color.black, 0);
        SteamVR_Fade.Start(Color.clear, 4.4f);
        player.position = new Vector3(-11.1f, -8.7f, -71.8f);
        body.velocity = new Vector3(0f, 0f, 0f);
    }
}
