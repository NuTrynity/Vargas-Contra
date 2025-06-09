using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public GameObject[] loot_table;
    public HealthComponent health_comp;
    public int loot_chance;

    void Start()
    {
        health_comp.die.AddListener(drop_loot);
    }

    public void drop_loot()
    {
        int rng = Random.Range(0, 100);
        if (rng <= loot_chance)
        {
            int rng_loot = Random.Range(0, loot_table.Length);
            Instantiate(loot_table[rng_loot], transform.position, Quaternion.identity);
        }
    }
}
