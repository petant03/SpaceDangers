using System;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class SpaceshipAbility : MonoBehaviour
{
    private SaveLoadSystem saveLoadSystem;

    public GameObject textMaxSpawnRate;
    public GameObject textDescriptionSpawnRate;
    public GameObject textMaxDamage;
    public GameObject textDescriptionDamage;
    public GameObject textMaxCollisionResistance;
    public GameObject textDescriptionCollisionResistance;

    public float spawnRate;
    public int damage;
    public int collisionResistance;
    private void Start()
    {
        saveLoadSystem = new SaveLoadSystem();
        
        LoadAbility();
    }

    public void Update()
    {
        #region SpawnRate
        if (textDescriptionSpawnRate != null)
            textDescriptionSpawnRate.GetComponent<Text>().text = "Spara un proiettile ogni " + this.spawnRate.ToString("F2") + " secondi.";

        if (this.spawnRate <= 0.1f)
        {
            if(textMaxSpawnRate != null)
                textMaxSpawnRate.SetActive(true);
        }
        #endregion

        #region Damage
        if (textDescriptionDamage != null)
            textDescriptionDamage.GetComponent<Text>().text = "Un proiettile infligge " + this.damage + " danni.";

        if (this.damage == 15)
        {
            if (textMaxDamage != null)
                textMaxDamage.SetActive(true);
        }
        #endregion

        #region CollisionResistance 
        if (textDescriptionCollisionResistance != null)
            textDescriptionCollisionResistance.GetComponent<Text>().text = "Resistenza a " + this.collisionResistance + " collisioni.";

        if (this.collisionResistance == 4)
        {
            if (textMaxCollisionResistance != null)
                textMaxCollisionResistance.SetActive(true);
        }
        #endregion
    }

    public string GetRecapAbility()
    {
        return spawnRate + ";" + damage + ";" + collisionResistance; 
    }

    public void UpgradeSpawnRate()
    {
        if (spawnRate > 0.5f)
        {
            spawnRate -= 0.1f;
            SaveAbility();
        }

    }

    public void UpgradeDamage()
    {
        if (damage < 15)
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
        saveLoadSystem.SaveAbility(this);
    }

    public void LoadAbility()
    {
        var data = saveLoadSystem.LoadAbility();

        if (data != null)
        {
            spawnRate = float.Parse(data.Split(';')[0]);
            damage = int.Parse(data.Split(';')[1]);
            collisionResistance = int.Parse(data.Split(';')[2]);
        }
        else
        {
            spawnRate = 1.5f;
            damage = 1;
            collisionResistance = 1;
        }
    }

    public float GetSpawnRate()
    {
        LoadAbility();
        return this.spawnRate;
    }

    public int GetDamage()
    {
        LoadAbility();
        return this.damage;
    }

    public int GetCollisionResistance()
    {
        LoadAbility();
        return this.collisionResistance;
    }
}
