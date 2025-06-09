using UnityEngine;

public class FlagScript : MonoBehaviour
{
    public WinScript win_screen;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            win_screen.game_win();
        }
    }
}
