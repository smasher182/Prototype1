using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    // reference to enemyPrefab.
    public GameObject enemyPrefab;
    // reference to spawn range.
    public float spawnRange = 9;
    void Start()
    {
        // gets random spawn position between -9 and 9 in X-axis.
        //float spawnPosX = Random.Range(-9, 9);
        float spawnPosX = Random.Range(-spawnRange, spawnRange);
        // gets random spawn position between -9 and 9 in Y-axis.
        //float spawnPosZ = Random.Range(-9, 9);
        float spawnPosZ = Random.Range(-spawnRange, spawnRange);

        // stores new vector3 position for randowm spawns in both axes. 
        Vector3 randomPos = new Vector3(spawnPosX, 0, spawnPosZ);
        // spawns enemy at the start at a predetermined location.
        //Instantiate(enemyPrefab, new Vector3(0, 0, 6), enemyPrefab.transform.rotation);

        //Instantiate(enemyPrefab, new Vector3(spawnPosX, 0, spawnPosZ), enemyPrefab.transform.rotation);
        // replaced randomPos after creating GenerateSpawnPoint() method.
        // Instantiate(enemyPrefab, randomPos, enemyPrefab.transform.rotation);
        Instantiate(enemyPrefab, GenerateSpawnPoint(), enemyPrefab.transform.rotation);
    }

    private Vector3 GenerateSpawnPoint()
    {
        float spawnPosX = Random.Range(-spawnRange, spawnRange);
        float spawnPosZ = Random.Range(-spawnRange, spawnRange);
        Vector3 randomPos = new Vector3(spawnPosX, 0, spawnPosZ);
        // returns the randomPos data from the method.
        return randomPos;
    }

}
