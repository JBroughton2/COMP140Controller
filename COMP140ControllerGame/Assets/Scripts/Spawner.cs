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
        spawnDelay = true;
        int index = Random.Range(0, fish.Length);
        Debug.Log("wow");
        Instantiate(fish[index], spawnPos.position, spawnPos.rotation);
        yield return new WaitForSeconds(delay);
        spawnDelay = false;
    }

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
