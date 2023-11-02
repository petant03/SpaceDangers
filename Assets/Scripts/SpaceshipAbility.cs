using UnityEngine;

[System.Serializable]
public class SpaceshipAbility : MonoBehaviour
{
    private SaveSystem saveSystem;
    private AbilityControllerUI abilityController;

    public float spawnRate;           //MAX 0.1 PARTE DA 1.5
    public int damage;          //MAX 15 PARTE DA 1
    public int collisionResistance;     //MAX 4 PARTE DA 1

    private void Start()
    {
        saveSystem = new SaveSystem();
        abilityController = new AbilityControllerUI();

        LoadAbility();
    }

    public void Update()
    {
        if (spawnRate <= 0.1f)
            abilityController.SetActiveTextSpawnRate();
    }

    public void UpgradeSpawnRate()
    {
        if (spawnRate > 0.1f)
        {
            spawnRate -= 0.1f;
            SaveAbility();
        }

    }

    public void UpgradeDamage()
    {
        if (damage < 10)
        {
            damage++;
            SaveAbility();
        }

    }

    public void UpgradeCollisionResistance()
    {
        if (collisionResistance < 4)
        {
            collisionResistance++;
            SaveAbility();
        }

    }

    private void SaveAbility()
    {
        saveSystem.SaveAbility(this);
    }

    public void LoadAbility()
    {
        SpaceshipAbility data = saveSystem.LoadAbility();
        
        if (data != null)
        {
            spawnRate = data.spawnRate;
            damage = data.damage;
            collisionResistance = data.collisionResistance;
        }
        else
        {
            spawnRate = 1.5f;
            damage = 1;
            collisionResistance = 1;
        }
    }
}
