using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    private GameObject Player;
    private Rigidbody2D rb;
    public float force;
    public float slowDownFactor = 0.1f;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Player = GameObject.FindGameObjectWithTag("Player");

        Vector3 direction = Player.transform.position - transform.position;
        rb.velocity = new Vector2(direction.x, direction.y).normalized * force;

        float rot = Mathf.Atan2(-direction.y, -direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, rot );
    }
    
    void Update()
    {
        
    }
}
