using UnityEngine;

public class WinScript : MonoBehaviour
{
    public CanvasGroup canvas_group;
    public AudioClip win_sound;

    void Start()
    {
        canvas_group.alpha = 0;
        canvas_group.blocksRaycasts = false;
        canvas_group.interactable = false;
    }

    public void game_win()
    {
        canvas_group.alpha = 1;
        canvas_group.blocksRaycasts = true;
        canvas_group.interactable = true;

        Time.timeScale = 0f;
        AudioComponent.instance.play_sound(win_sound, transform, 1f);
    }
}
