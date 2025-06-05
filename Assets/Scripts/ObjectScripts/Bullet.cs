using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int damage;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float speed = 1024f;
    [SerializeField] private float life_time = 5f;

    void Start()
    {
        Destroy(gameObject, life_time);
    }

    void FixedUpdate()
    {
        rb.linearVelocity = transform.right * speed * Time.deltaTime;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            return;
        }

        HealthComponent enemy_health = collision.GetComponent<HealthComponent>();
        if (enemy_health != null)
        {
            enemy_health.damage(-damage);
        }
    }

    public void set_properties(int bullet_damage, Vector2 direction)
    {
        damage = bullet_damage;

        if (rb != null)
        {
            rb.linearVelocity = direction.normalized * speed * Time.deltaTime;
        }
    }
}
