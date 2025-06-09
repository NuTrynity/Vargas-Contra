using System.Collections;
using UnityEngine;

public class EnemyTurret : MonoBehaviour
{
    [Header("Turret rotation properties")]
    public Transform player;

    [Header("Turret weapon properties")]
    public GameObject bullet;
    public AudioClip turret_audio;
    public int turret_damage;
    public float fire_rate;
    public float player_distance;

    private bool can_fire = true;

    void Start()
    {
        if (player == null)
        {
            player = GameObject.FindWithTag("Player").transform;
        }
    }

    void Update()
    {
        if (player != null)
        {
            look_at_player();
            shoot_at_player();
        }

    }

    private void shoot_at_player()
    {
        if (Vector3.Distance(transform.position, player.position) < player_distance)
        {
            shoot();
        }
    }

    private void look_at_player()
    {
        Vector3 direction = player.position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.Euler(0f, 0f, angle);
    }

    private void shoot()
    {
        if (!can_fire)
        {
            return;
        }

        GameObject new_bullet = Instantiate(bullet, transform.position, transform.rotation);
        Bullet bullet_script = new_bullet.GetComponent<Bullet>();

        bullet_script.set_properties(turret_damage, transform.right);

        AudioComponent.instance.play_sound(turret_audio, transform, 0.7f);

        StartCoroutine(cooldown());
    }

    private IEnumerator cooldown()
    {
        can_fire = false;
        yield return new WaitForSeconds(fire_rate);
        can_fire = true;
    }
}
