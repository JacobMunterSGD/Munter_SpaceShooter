using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{

    public GameObject enemy;

    float timer;
    public float timerStartValue;

    public float spawnRange;

    private void Start()
    {
        timer = timerStartValue;
    }

    void Update()
    {
        if (timer >= 0)
        {
            timer -= Time.deltaTime;
        }
        else
        {
            spawnEnemy();
            timer = timerStartValue;
        }
    }

    void spawnEnemy()
    {

        Vector3 spawnOffset = new Vector3(Random.Range(-spawnRange, spawnRange), Random.Range(-spawnRange, spawnRange), 0);
        Instantiate(enemy, transform.position + spawnOffset, Quaternion.identity);

    }
}
