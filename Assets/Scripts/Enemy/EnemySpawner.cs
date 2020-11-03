using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Component responsible of spawning wolves, given set respawn points and spawn frequency values.
/// </summary>
public class EnemySpawner : MonoBehaviour
{
    [SerializeField] Transform wolfPrefab;
    [SerializeField] Transform wolfEaterPrefab;
    [SerializeField] Transform[] spawnPoints;

    [SerializeField] int eaterChance = 3;     //Chance out of 10 wolves to spawn an eater wolf
    [SerializeField] float spawnTime;         //Initial spawn delay per wolf
    [SerializeField] float spawnReductionPer; //Reduction in spawn delay per each wolf spawn
    [SerializeField] float spawnFloor;        //Minimum spawn delay per wolf

    float currentSpawnTime;
    float timer;

    void Start()
    {
        currentSpawnTime = spawnTime;
        timer = Time.time;
    }

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
        //Calculate eater wolf chance
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
