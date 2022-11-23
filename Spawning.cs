using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawning : MonoBehaviour
{
    public GameObject enemy;
    private float spawnRange=11;
    public int enemyCount;
    public int waveNo = 1;
    public GameObject powerupPrefab;
    public GameObject powerup;
    public int bombcount;
    public GameObject bomb;
    // Start is called before the first frame update
    void Start()
    {
        SpawnEnemyWave(waveNo);
        Instantiate(powerup, GenereaterandomPosition(), powerup.transform.rotation);

    }



    void SpawnEnemyWave(int enemiesToSpawn)
    {
        Vector3 powerupSpawnOffset = new Vector3(0, 0, -15);
        if (GameObject.FindGameObjectsWithTag("Powerup").Length == 0) // check that there are zero powerups
        {
            Instantiate(powerupPrefab, GenereaterandomPosition() + powerupSpawnOffset, powerupPrefab.transform.rotation);
        }
        for (int i=0;i< enemiesToSpawn; i++)
        {
            Instantiate(enemy, GenereaterandomPosition(), enemy.transform.rotation);
        }
    }


    // Update is called once per frame
    void Update()
    {
        enemyCount = FindObjectsOfType<enemyscript>().Length;
        bombcount = FindObjectsOfType<Bomb>().Length;

        if (bombcount == 0)
        {
            bombcount++;
            Instantiate(bomb, GenereaterandomPosition(), powerup.transform.rotation);
            Instantiate(bomb, GenereaterandomPosition(), powerup.transform.rotation);
            Instantiate(bomb, GenereaterandomPosition(), powerup.transform.rotation);
        }


            if (enemyCount == 0) 
        {
            waveNo++;
            SpawnEnemyWave(waveNo);
            Instantiate(powerup, GenereaterandomPosition(), powerup.transform.rotation);
            
        }
    }

    private Vector3 GenereaterandomPosition()
    {
        float spawnPosX = Random.Range(-spawnRange, spawnRange);
        float spawnPosZ = Random.Range(-spawnRange, spawnRange);
        Vector3 randomPos = new Vector3(spawnPosX, 0, spawnPosZ);
        return randomPos;


    }




}
