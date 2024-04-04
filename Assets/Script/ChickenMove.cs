using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChickenMove : MonoBehaviour
{
    public float velocity = 5f;
    public Vector3 minStopPosition; 
    public Vector3 maxStopPosition;
    public Vector3 stopPosition; 
    private bool stop = false;


    private void Start()
    {
        float randomX = Random.Range(minStopPosition.x, maxStopPosition.x);
        float randomY = Random.Range(minStopPosition.y, maxStopPosition.y);

        stopPosition = new Vector3(randomX, randomY, transform.position.z);
    }

    private void Update()
    {
        if (!stop)
        {
            transform.position = Vector3.MoveTowards(transform.position, stopPosition, velocity * Time.deltaTime);

            if (transform.position == stopPosition)
            {
                stop = true;

            }
        }
    }

}
