using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    [SerializeField] private float damage;  
    [SerializeField] private AudioClip PlayerDamage;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            AudioSource.PlayClipAtPoint(PlayerDamage, transform.position, 1f);

            collision.GetComponent<Health>().TakeDamage(damage);

            Destroy(gameObject);
        }
    }

}
