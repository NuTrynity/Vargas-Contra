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

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("Player"))
        {
            HealthComponent health_component = collision.GetComponent<HealthComponent>();
            if (health_component != null)
            {
                health_component.damage(-damage);
                Destroy(gameObject);
            }
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
