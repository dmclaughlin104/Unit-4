using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    //variables
    public GameObject enemyPrefab;
    public GameObject powerUpPrefab;
    public GameObject player;
    private float spawnRange = 9.0f;
    public int enemyCount;
    private int nextWave = 1;

    //private string message = "GAME OVER!";


    // Start is called before the first frame update
    void Start()
    {
        SpawnEnemyWave(nextWave);
        SpawnPowerUp(GenerateSpawnPos());
    }

    // Update is called once per frame
    void Update()
    {
        //setting enemy count - N.B. using the scripts applied, not the tag
        enemyCount = FindObjectsOfType<Enemy>().Length;

        //if all enemies are defeated, spawn more
        if ((enemyCount == 0) && (player.transform.position.y > -20))
        {
            nextWave++;
            SpawnEnemyWave(nextWave);
            SpawnPowerUp(GenerateSpawnPos());
        }

        //player falls off side, print Game Over to log
        if (player.transform.position.y <= -20)
        {
            Debug.Log("You have fallen off: Game Over");
        }

        //exploring GUI - to look at again when I have more time...
        /*
        void OnGUI()
        {
            GUI.Label(Rect(0, 0, 100, 100), message);
        }
        */
    }

    //method to spawn a wave of enemies
    void SpawnEnemyWave(int pWaveNumber)
    {
        for (int count = 0; count < pWaveNumber; count++)
        {
            Instantiate(enemyPrefab, GenerateSpawnPos(), enemyPrefab.transform.rotation);
        }
    }

    //method to instantiate a Power Up
    void SpawnPowerUp(Vector3 pRandomPosition)
    {
        Instantiate(powerUpPrefab, GenerateSpawnPos(), powerUpPrefab.transform.rotation);
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
