using UnityEngine;

public class WeaponBox : MonoBehaviour
{
    public GameObject[] weapon_pool;
    public Rigidbody2D rb;
    public AudioClip pickup_audio;
    [SerializeField] private float jump_force;

    void Start()
    {
        rb.AddForce(transform.up * jump_force);
        Destroy(gameObject, 5f);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerGunManager pgm = collision.GetComponent<PlayerGunManager>();
        if (pgm != null)
        {
            pgm.change_weapon(weapon_pool[Random.Range(0, weapon_pool.Length)]);
            AudioComponent.instance.play_sound(pickup_audio, transform, 1f);
            Destroy(gameObject);
        }
    }
}
