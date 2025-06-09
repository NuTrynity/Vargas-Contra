using UnityEngine;

public class GameUI : MonoBehaviour
{
    public CanvasGroup canvas_group;
    public GameObject player;

    void Start()
    {
        PlayerGunManager player_weapon = player.GetComponent<PlayerGunManager>();
        if (player_weapon != null)
        {
            // get the ammo count here
        }
    }
}
