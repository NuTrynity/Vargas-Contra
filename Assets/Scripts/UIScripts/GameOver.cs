using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public CanvasGroup canvas_group;
    public GameObject player;
    public AudioClip gameover_sound;

    void Start()
    {
        HealthComponent player_health = player.GetComponent<HealthComponent>();
        if (player != null)
        {
            player_health.die.AddListener(game_over);
        }

        canvas_group.alpha = 0;
        canvas_group.blocksRaycasts = false;
        canvas_group.interactable = false;
    }

    public void game_over()
    {
        canvas_group.alpha = 1;
        canvas_group.blocksRaycasts = true;
        canvas_group.interactable = true;

        Time.timeScale = 0f;
        AudioComponent.instance.play_sound(gameover_sound, transform, 1f);
    }

    public void retry_game()
    {
        SceneManager.LoadScene("SampleScene");
        Time.timeScale = 1f;
    }

    public void quit_game()
    {
        Application.Quit();
    }
}
