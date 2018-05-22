using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class LevelManager : MonoBehaviour {

    public static LevelManager instance;
    public Animator animator;
    public Transform player;
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
        if (player.position.y >= 16 && goodPlayed == false)
        {
            goodPlayed = true;
            FindObjectOfType<AudioManager>().Play("Good");
            FindObjectOfType<AudioManager>().currentAudio.Stop();
            FindObjectOfType<AudioManager>().Play("BGM2");
            
        }
    }
    
    public void FadeToLevel(int levelIndex)
    {
        //levelToLoad = levelIndex;
        animator.SetBool("FO", true);
        animator.SetBool("FI", false);
    }

    public void OnFadeComplete()
    {
        //SceneManager.LoadScene(levelToLoad);
        animator.SetBool("FO", false);
        animator.SetBool("FI", true);
        player.position = new Vector3(-11.1f, -8.7f, -71.8f);
    }
}
