using UnityEngine;

public class HealthCollectible : MonoBehaviour
{
    [SerializeField] private float healthValue;
    [SerializeField] private AudioClip Chicken;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {   
            AudioSource.PlayClipAtPoint(Chicken, transform.position, 1f);
            collision.GetComponent<Health>().AddHealth(healthValue);
            gameObject.SetActive(false);
            
        }
    }
}
