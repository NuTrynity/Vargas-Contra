using UnityEngine;
using UnityEngine.Events;

public class HealthComponent : MonoBehaviour
{
    public UnityEvent died;

    public int max_health;
    private int health;

    void Start()
    {
        health = max_health;
    }

    public void damage(int value)
    {
        health += value;

        if (health <= 0)
        {
            died.Invoke();
        }
    }
}
