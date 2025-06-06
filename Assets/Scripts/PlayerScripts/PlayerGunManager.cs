using UnityEngine;

public class PlayerGunManager : MonoBehaviour
{
    public GameObject starter_weapon;
    public GameObject player_weapon;

    void Start()
    {
        if (player_weapon == null)
        {
            change_weapon(starter_weapon);
        }
    }

    public void change_weapon(GameObject weapon)
    {
        Destroy(player_weapon);
        player_weapon = Instantiate(weapon, transform.position, transform.rotation);
        player_weapon.transform.SetParent(transform);
        Debug.Log($"Weapon changed to {weapon}");
    }
}
