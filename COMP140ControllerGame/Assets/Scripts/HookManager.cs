using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HookManager : MonoBehaviour
{
    public Text scoreText;
    public GameObject lossScreen;

    private bool fishHooked;
    private bool loseGame;
    private int score;

    private void Awake()
    {
        //I have to set this from awake as when reloading the scene it would load frozen, this however counteracts that.
        Time.timeScale = 1;
    }

    //In update I'm managing all the scoring system.
    private void Update()
    {
        scoreText.text = "Score: " + score;

        if(score < 0)
        {
            loseGame = true;
            Time.timeScale = 0;
        }

        if(loseGame)
        {
            lossScreen.SetActive(true);
        }
    }

    //This is the main manager for grabbing the fish and also releasing it if the player has hit an obstacle
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Fish") && !fishHooked)
        {
            //It starts by getting the fishAI script so that I can access variables from it.
            var fishMovement = col.GetComponent<FishAI>();
            //This will then set the fish's parent to be the players hook.
            col.transform.parent = this.gameObject.transform;
            //then set this to true to stop it from moving.
            fishMovement.caught = true;
            //this is a bool used to stop the fish from having multiple fish caught at once.
            fishHooked = true;
        }

        if (col.CompareTag("Obstacle"))
        {
            foreach(Transform child in transform)
            {
                var fishMovement = GetComponentInChildren<FishAI>();
                fishMovement.caught = false;
                StartCoroutine(fishMovement.ReleasedTimer());
                child.parent = null;
                score -= 1;
                fishHooked = false;
            }
        }

        //This is checking if the player has caught a fish and pulled it up to the scoring zone.
        if (col.CompareTag("ScoreBox") && fishHooked)
        {
            //This then checks through all children attached to the hook and destroy them.
            foreach (Transform child in transform)
            {
                Destroy(child.gameObject);
                //After being destroyed the player will gain a point.
                score += 1;
                //and be able to grab another fish.
                fishHooked = false;
            }
        }
    }
}
