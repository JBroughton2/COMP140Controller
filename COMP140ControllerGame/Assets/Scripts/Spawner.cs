using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] fish;
    public GameObject[] obstacles;
    public Transform spawnPos;
    [SerializeField]
    private bool fishOrObstacles;
    [SerializeField]
    private float delay;
    [SerializeField]
    private float obstacleDelay;

    private bool spawnDelay;
    private int fishIndex;
    private int obsacleIndex;

    private void Start()
    {
        spawnDelay = false;
    }

    private void Update()
    {
        //These delays are used to give the spawners a small delay so the screen isn't filled with them every frame.
        if (!spawnDelay && !fishOrObstacles)
        {
            StartCoroutine(SpawnTimerFish());
        }

        if(!spawnDelay && fishOrObstacles)
        {
            StartCoroutine(SpawnTimerObstacle());
        }
    }
    
    IEnumerator SpawnTimerFish()
    {
        //This will set the delay to true to stop it from spawning more fish
        spawnDelay = true;
        //it will then create a random index within the fish array that will be used to pick a random fish out
        int index = Random.Range(0, fish.Length);
        //This will then spawn the fish into the world that is randomly picked to make the fish look different.
        Instantiate(fish[index], spawnPos.position, Quaternion.Euler(0, 180, 0));
        //This will then wait for a set amount of time and then set it to false so the spawner can start again.
        yield return new WaitForSeconds(delay);
        spawnDelay = false;
    }

    //The object spawner works in the same way as the fish spawner however the delay is a little longer.
    IEnumerator SpawnTimerObstacle()
    {
        spawnDelay = true;
        int index = Random.Range(0, obstacles.Length);
        Debug.Log("wow");
        Instantiate(obstacles[index], spawnPos.position, spawnPos.rotation);
        yield return new WaitForSeconds(obstacleDelay);
        spawnDelay = false;
    }

}
