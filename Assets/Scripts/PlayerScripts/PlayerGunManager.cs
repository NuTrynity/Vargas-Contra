using UnityEngine;

public class PlayerGunManager : MonoBehaviour
{
    public GameObject starter_weapon;
    public GameObject player_weapon;

    void Start()
    {
        change_weapon(starter_weapon);
    }

    public void change_weapon(GameObject weapon)
    {
        player_weapon = weapon;
    }
}
