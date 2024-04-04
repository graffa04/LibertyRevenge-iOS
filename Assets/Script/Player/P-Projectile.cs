using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float Speed = 4.5f;
    private Vector3 direction;
    
    void Start()
    {
        float rot = Mathf.Atan2(-direction.y, -direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, rot + 180);
    }
    public void SetDirection(Vector3 newDirection)
    {
        direction = newDirection;
    }

    void Update()
    {
        transform.position += direction * Speed * Time.deltaTime; 
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemys"))
        {
            Destroy(collision.gameObject);

            Destroy(gameObject);
        }
    }
}
