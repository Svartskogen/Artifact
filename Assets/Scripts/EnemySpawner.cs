using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public Transform wolfPrefab;
    public Transform wolfEaterPrefab;

    public Transform[] spawnPoints;

    public int eaterChance = 3;
    public float spawnTime;
    public float spawnFloor;
    public float spawnReductionPer;

    float currentSpawnTime;
    float timer;
    // Start is called before the first frame update
    void Start()
    {
        currentSpawnTime = spawnTime;
        timer = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time > timer)
        {
            Spawn();
            currentSpawnTime -= spawnReductionPer;
            if(currentSpawnTime <= spawnFloor)
            {
                currentSpawnTime = spawnFloor;
            }
            timer = Time.time + currentSpawnTime;
        }
    }
    void Spawn()
    {
        if(Random.Range(0,11) > eaterChance)
        {
            Instantiate(wolfPrefab, spawnPoints[Random.Range(0, spawnPoints.Length)].position, Quaternion.identity);
        }
        else
        {
            Instantiate(wolfEaterPrefab, spawnPoints[Random.Range(0, spawnPoints.Length)].position, Quaternion.identity);
        }
    }
}
