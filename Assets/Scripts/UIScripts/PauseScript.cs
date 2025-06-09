using UnityEngine;

public class PauseScript : MonoBehaviour
{
    private bool is_paused = false; 
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            is_paused = !is_paused;
            toggle_pause(is_paused);
        }
    }

    public void toggle_pause(bool condition)
    {
        if (condition)
        {
            Time.timeScale = 0.0f;
        }
        else
        {
            Time.timeScale = 1.0f;
        }
    }
}
