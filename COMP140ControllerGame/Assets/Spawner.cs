using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] fish;
    public GameObject[] obstacles;

    [SerializeField]
    private Transform spawnPos;
    [SerializeField]
    private bool fishOrObstacles;
    [SerializeField]
    private float delay;

    private bool spawnDelay;
    private int fishIndex;
    private int obsacleIndex;

    private void Start()
    {
        spawnDelay = false;
    }

    void Update()
    {
        if (!spawnDelay)
        {
            StartCoroutine(SpawnTimer());
        }
    }

    IEnumerator SpawnTimer()
    {
        //spawnDelay = true;
        Instantiate(fish[UnityEngine.Random.Range(0, fish.Length - 1)], spawnPos);
        yield return new WaitForSeconds(delay);
        spawnDelay = false;
    }
}
