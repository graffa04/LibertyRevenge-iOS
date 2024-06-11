using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour
{
    [SerializeField] private AudioClip BulletEnemies;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Bullet")
        {
            AudioSource.PlayClipAtPoint(BulletEnemies, transform.position, 1f);
            Destroy(collision.gameObject);
        }
    }
}
