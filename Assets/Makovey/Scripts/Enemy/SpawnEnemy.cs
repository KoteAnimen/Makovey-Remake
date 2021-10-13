using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    public GameObject[] enemies;
    public int maxEnemyCount;
    public Transform[] spawnPoints;
    public float minTimeInterval;
    public float maxTimeInterval;
    private float timeInterval = 0;
    private bool spawn = false;
    private int currentEnemyCount = 0;

    void Start()
    {
        StartCoroutine(Spawn());
    }

    IEnumerator Spawn()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.1f);
            if(timeInterval == 0)
            {
                timeInterval = Random.Range(minTimeInterval, maxTimeInterval);
                spawn = true;
            }
            if (spawn && currentEnemyCount < maxEnemyCount)
            {
                yield return new WaitForSeconds(timeInterval);
                int rnd = Random.Range(0, spawnPoints.Length);
                Instantiate(enemies[0], spawnPoints[rnd].position, spawnPoints[rnd].rotation);
                timeInterval = 0;
                currentEnemyCount++;
            }
        }
    }
    
    
}
