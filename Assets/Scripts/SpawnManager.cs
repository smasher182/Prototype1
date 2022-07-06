using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    // reference to enemyPrefab.
    public GameObject enemyPrefab;
    // reference to spawn range.
    public float spawnRange = 9;
    // reference to number of enemies.
    public int enemyCount;
    // reference to number of enemy waves.
    public int waveNumber = 1;
    // reference to powerPrefab gameObject.
    public GameObject powerUpPrefab;
    // reference to barrier spawn array.
    public GameObject[] barrierSpawn;

    public GameObject barrier;
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
        // removed after creating for loop for enemy spawn.
        //Instantiate(enemyPrefab, GenerateSpawnPoint(), enemyPrefab.transform.rotation);

        // changed after using the wave number variable.
        //SpawnEnemyWave(3);
        SpawnEnemyWave(waveNumber);

        // spawns powerUpPrefabs at the start.
        Instantiate(powerUpPrefab, GenerateSpawnPoint(), powerUpPrefab.transform.rotation);

        
    }

    private void Update()
    {
        // finds the number of enemies in the scene.
        enemyCount = FindObjectsOfType<Enemy>().Length;
        //
        if (enemyCount == 0)
        {
            // increases wave number after each enemy waves defeated.
            waveNumber++;
            // spawns one more enemy if enemy count goes to zero.
            // changed after using the wave number variable.
            //SpawnEnemyWave(1);
            SpawnEnemyWave(waveNumber);

            // spawns powerUpPrefabs at the given position.
            Instantiate(powerUpPrefab, GenerateSpawnPoint(), powerUpPrefab.transform.rotation);

           
        }

        if (Input.GetKeyDown(KeyCode.B))
        {
            SpawnBarrier();
        }
    }
    void SpawnEnemyWave(int enemiesToSpawn)
    {
        /* for (int i = 0; i < 3; i++)
         {
             Instantiate(enemyPrefab, GenerateSpawnPoint(), enemyPrefab.transform.rotation);
         }
        */

        // passed a parameter in spawnEnemyWave function.
        for (int i = 0; i < enemiesToSpawn; i++)
        {
            Instantiate(enemyPrefab, GenerateSpawnPoint(), enemyPrefab.transform.rotation);
        }

    }
    private Vector3 GenerateSpawnPoint()
    {
        float spawnPosX = Random.Range(-spawnRange, spawnRange);
        float spawnPosZ = Random.Range(-spawnRange, spawnRange);
        Vector3 randomPos = new Vector3(spawnPosX, 0, spawnPosZ);
        // returns the randomPos data from the method.
        return randomPos;
    }

    void SpawnBarrier()
    {
        for (int i = 0; i < barrierSpawn.Length; i++)
        {
            int rndSpawn = Random.Range(0, barrierSpawn.Length);
            Instantiate(barrier, barrierSpawn[rndSpawn].transform.position, barrierSpawn[rndSpawn].transform.rotation);
        }

    }
}
