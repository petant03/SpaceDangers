using UnityEngine;

public class SpaceshipAbility : MonoBehaviour
{
    public GameObject textMaxSpawnRate;

    public float spawnRate;
    public float damage;
    public int collisionResistance;

    private void Start()
    {
        LoadAbility();
    }

    public void Update()
    {
        if (spawnRate <= 0.1f)
            textMaxSpawnRate.SetActive(true);
    }

    public void UpgradeSpawnRate()
    {
        if (spawnRate > 0.1f)
            spawnRate -= 0.1f;

        SaveAbility();
    }

    public void UpgradeDamage()
    {
        SaveAbility();
    }

    public void UpgradeCollisionResistance()
    {
        SaveAbility();
    }

    private void SaveAbility()
    {
        SaveSystem.SaveAbility(this);
    }

    public void LoadAbility()
    {
        SpaceshipAbility data = SaveSystem.LoadAbility();

        if (data != null)
        {
            spawnRate = data.spawnRate;
            damage = data.damage;
            collisionResistance = data.collisionResistance;
        }
    }
}
