using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    private AudioSource audioSource;
    public float velocity = 5f;
    public float stopTime = 2f; 
    public float shootInterval = 1f;
    public Vector3 minStopPosition; 
    public Vector3 maxStopPosition;
    public Vector3 stopPosition; 
    private bool canShoot = false;
    private bool stop = false;
    public GameObject bullet; 
    public Transform bulletPos; 
    private float stopTimer = 0f; 
    private float shootTimer = 0f; 

    void Start()
    {
        float randomX = Random.Range(minStopPosition.x, maxStopPosition.x);
        float randomY = Random.Range(minStopPosition.y, maxStopPosition.y);

        stopPosition = new Vector3(randomX, randomY, transform.position.z);
    }
    void Update()
    {
        if (!stop)
        {
            transform.position = Vector3.MoveTowards(transform.position, stopPosition, velocity * Time.deltaTime);

            if (transform.position == stopPosition)
            {
                stop = true;
                stopTimer = 0f; 
            }
        }
        else
        {
            stopTimer += Time.deltaTime;

            if (stopTimer >= stopTime)
            {
                canShoot = true;
            }
        }

        if (canShoot)
        {
            shootTimer += Time.deltaTime;

            if (shootTimer >= shootInterval)
            {
                shoot();
                shootTimer = 0f;
                canShoot = false;
                stop = false;
            }
        }
    }

    void shoot()
    {
        Instantiate(bullet, bulletPos.position, Quaternion.identity);
    }
}
