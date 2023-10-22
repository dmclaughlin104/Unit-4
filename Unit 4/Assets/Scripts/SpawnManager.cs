using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject enemyPrefab;
    private float spawnRange = 9.0f;
    public int enemyCount;
    private int nextWave = 1;


    // Start is called before the first frame update
    void Start()
    {
        SpawnEnemyWave(nextWave);
    }

    // Update is called once per frame
    void Update()
    {
        //setting enemy count - N.B. using the scripts applied, not the tag
        enemyCount = FindObjectsOfType<Enemy>().Length;

        //if all enemies are defeated, spawn more
        if (enemyCount == 0)
        {
            nextWave++;
            SpawnEnemyWave(nextWave);
        }
        
    }


    void SpawnEnemyWave(int pWaveNumber)
    {
        for (int count = 0; count < pWaveNumber; count++)
        {
            Instantiate(enemyPrefab, GenerateSpawnPos(), enemyPrefab.transform.rotation);
        }
    }



    //method to generate a new random spawn position
    private Vector3 GenerateSpawnPos() 
    {
        //variables
        float spawnPosX = Random.Range(-spawnRange, spawnRange);
        float spawnPosZ = Random.Range(-spawnRange, spawnRange);

        //assigning random variables to Vector variables
        Vector3 spawnPos = new Vector3(spawnPosX, 1.0f, spawnPosZ);

        return spawnPos;
    }

}
