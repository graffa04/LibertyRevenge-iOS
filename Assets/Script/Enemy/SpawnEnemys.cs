using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObstacles : MonoBehaviour
{
    public GameObject obstacle;
    public float maxX;
    public float minX;
    public float maxY;
    public float minY;
    public float timeBetweenSpawn;
    private float spawnTime;

    // Valore minimo per timeBetweenSpawn
    public float minTimeBetweenSpawn = 2.0f;
    // Quanto diminuire timeBetweenSpawn ogni volta
    public float spawnTimeDecrement = 0.1f;

    // Update is called once per frame
    void Update()
    {
        if (Time.time > spawnTime)
        {
            Spawn();
            spawnTime = Time.time + timeBetweenSpawn;

            // Diminuisci il tempo tra gli spawn ma non andare sotto il minimo
            timeBetweenSpawn = Mathf.Max(minTimeBetweenSpawn, timeBetweenSpawn - spawnTimeDecrement);
        }
    }

    void Spawn()
    {
        float randomX = Random.Range(minX, maxX);
        float randomY = Random.Range(minY, maxY);

        Instantiate(obstacle, transform.position + new Vector3(randomX, randomY, 0), transform.rotation);
    }
}
