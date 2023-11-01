using UnityEngine;

public class SpaceshipAbility : MonoBehaviour
{
    public GameObject textMaxSpawnRate;

    public static float spawnRate = 1.5f;
    public static float damage;
    public static float collisionResistance;

    public void UpgradeSpawnRate()
    {
        if (spawnRate > 0.1f)
            spawnRate -= 0.1f;
    }

    public void Update()
    {
        if(spawnRate <= 0.1f)
            textMaxSpawnRate.SetActive(true);
    }
}
