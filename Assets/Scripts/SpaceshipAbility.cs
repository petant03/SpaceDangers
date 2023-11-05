using System;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class SpaceshipAbility : MonoBehaviour
{
    private SaveSystem saveSystem;

    public GameObject textMaxSpawnRate;
    public GameObject textDescriptionSpawnRate;
    
    public float spawnRate;             //MAX 0.1 PARTE DA 1.5
    public int damage;                  //MAX 15 PARTE DA 1
    public int collisionResistance;     //MAX 4 PARTE DA 1

    private void Start()
    {
        saveSystem = new SaveSystem();
        
        LoadAbility();
    }

    public void Update()
    {
        textDescriptionSpawnRate.GetComponent<Text>().text = "Spara un proiettile ogni " + spawnRate.ToString("F2") + " secondi.";

        if (spawnRate <= 0.1f)
            textMaxSpawnRate.SetActive(true);
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
        var data = saveSystem.LoadAbility();

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
}
