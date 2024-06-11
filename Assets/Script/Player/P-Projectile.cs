using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float Speed = 4.5f;
    private Vector3 direction;
    [SerializeField] private AudioClip DestroyEnemies;

    void Start()
    {
        // Rotazione iniziale del proiettile
        float rot = Mathf.Atan2(-direction.y, -direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, rot + 180);
    }

    public void SetDirection(Vector3 newDirection)
    {
        direction = newDirection;
    }

    void Update()
    {
        // Movimento del proiettile
        transform.position += direction * Speed * Time.deltaTime;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemys"))
        {
            // Riproduce il suono alla posizione del proiettile
            if (DestroyEnemies != null)
            {
                AudioSource.PlayClipAtPoint(DestroyEnemies, transform.position, 1f);
            }

            // Distrugge il nemico
            Destroy(collision.gameObject);

            // Distrugge il proiettile
            Destroy(gameObject);
        }
    }
}
