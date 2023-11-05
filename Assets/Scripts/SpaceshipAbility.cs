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

        //abilityController.SetSpawnRateDescription(spawnRate);

        //if (spawnRate <= 0.1f)
        //    abilityController.SetActiveTextSpawnRate();
    }

    public override string ToString()
    {
        return spawnRate + ";" + damage + ";" + collisionResistance; 
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
        var data = saveSystem.LoadAbility().Split(';');

        if (data != null)
        {
            spawnRate = float.Parse(data[0]);
            damage = int.Parse(data[1]);
            collisionResistance = int.Parse(data[2]);
        }
    }
}
