using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject enemyPrefab;
    private float spawnRange = 9.0f;


    // Start is called before the first frame update
    void Start()
    {
        Instantiate(enemyPrefab, GenerateSpawnPos(), enemyPrefab.transform.rotation);

    }

    // Update is called once per frame
    void Update()
    {
        
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
