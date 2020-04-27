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
        Time.timeScale = 1;
    }

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

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Fish") && !fishHooked)
        {
            var fishMovement = col.GetComponent<FishAI>();
            col.transform.parent = this.gameObject.transform;
            fishMovement.caught = true;
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

        if (col.CompareTag("ScoreBox") && fishHooked)
        {
            foreach (Transform child in transform)
            {
                Destroy(child.gameObject);
                score += 1;
                fishHooked = false;
            }
        }
    }
}
