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

    private bool spawnDelay;
    private int fishIndex;
    private int obsacleIndex;

    private void Start()
    {
        spawnDelay = false;
    }

    private void Update()
    {
        if (!spawnDelay)
        {
            StartCoroutine(SpawnTimer());
        }
    }
    
    IEnumerator SpawnTimer()
    {
        spawnDelay = true;
        int index = Random.Range(0, fish.Length);
        Debug.Log("wow");
        Instantiate(fish[index], spawnPos.position, spawnPos.rotation);
        yield return new WaitForSeconds(delay);
        spawnDelay = false;
    }
    
}
