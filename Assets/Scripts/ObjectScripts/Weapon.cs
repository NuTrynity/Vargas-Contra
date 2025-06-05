using System.Collections;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public GameObject bullet;
    public Transform barrel;
    public int weapon_damage;
    public int bullet_amt;
    public int ammo;
    public float fire_rate;

    [Range(0f, 45f)] public float spread_angle = 5f;

    private PlayerMovement p_script;
    private bool can_fire = true;

    void Start()
    {
        if (p_script == null)
        {
            p_script = GetComponentInParent<PlayerMovement>();
        }
    }

    void Update()
    {
        face_gun();

        if (Input.GetMouseButton(0))
        {
            shoot();
        }
    }

    private void face_gun()
    {
        if (Input.GetKey(KeyCode.W))
        {
            transform.rotation = Quaternion.Euler(0f, p_script.p_rotation, 90f);
        }
        else if (Input.GetKey(KeyCode.S))
        {
            transform.rotation = Quaternion.Euler(0f, p_script.p_rotation, -90f);
        }
        else
        {
            transform.rotation = Quaternion.Euler(0f, p_script.p_rotation, 0f);
        }
    }

    private IEnumerator cooldown()
    {
        can_fire = false;
        yield return new WaitForSeconds(fire_rate);
        can_fire = true;
    }

    public virtual void shoot()
    {
        if (ammo <= 0 || !can_fire)
        {
            return;
        }

        Vector2 base_dir = transform.right;

        for (int i = 0; i < bullet_amt; i++)
        {
            float rand_spread = Random.Range(-spread_angle, spread_angle);
            Quaternion spread_rotation = Quaternion.Euler(0f, 0f, rand_spread);

            Vector2 spread_dir = spread_rotation * base_dir;

            GameObject new_bullet = Instantiate(bullet, barrel.position, barrel.rotation);
            Bullet bullet_script = new_bullet.GetComponent<Bullet>();

            bullet_script.set_properties(weapon_damage, spread_dir);
        }

        ammo--;
        StartCoroutine(cooldown());
    }
}
