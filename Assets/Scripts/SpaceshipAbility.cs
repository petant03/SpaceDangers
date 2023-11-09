using System;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class SpaceshipAbility : MonoBehaviour
{
    private SaveLoadSystem ss;

    private int coins;
    private const string upgrade = "Il prossimo miglioramento costa {0} monete.";

    public GameObject textMaxSpawnRate;
    public GameObject textDescriptionSpawnRate;
    public GameObject textNextUpgradeSpawnRate;

    public GameObject textMaxDamage;
    public GameObject textDescriptionDamage;
    public GameObject textNextUpgradeDamage;

    public GameObject textMaxCollisionResistance;
    public GameObject textDescriptionCollisionResistance;
    public GameObject textNextUpgradeCollisionResistance;

    public GameObject alertCoins;

    public float spawnRate;
    public int damage;
    public int collisionResistance;

    private void Start()
    {
        ss = new SaveLoadSystem();
        coins = ss.LoadCoins() != null ? int.Parse(ss.LoadCoins()) : 0;
        LoadAbility();
    }

    public void Update()
    {
        #region SpawnRate
        var costoPerMiglioramentoSpawnRate = GenericService.GetCostoSpawnRate()[Mathf.FloorToInt((spawnRate * 10) - 1)];
        
        if (textDescriptionSpawnRate != null)
            textDescriptionSpawnRate.GetComponent<Text>().text = "Spara un proiettile ogni " + this.spawnRate.ToString("F2") + " secondi.";

        if (this.spawnRate <= 0.5f)
        {
            if(textMaxSpawnRate != null)
                textMaxSpawnRate.SetActive(true);
        }

        textNextUpgradeSpawnRate.GetComponent<Text>().text = String.Format(upgrade, costoPerMiglioramentoSpawnRate.ToString());
        #endregion

        #region Damage
        var costoPerMiglioramentoDamage = GenericService.GetCostoDamage()[damage + 1];

        if (textDescriptionDamage != null)
            textDescriptionDamage.GetComponent<Text>().text = "Un proiettile infligge " + this.damage + " danni.";

        if (this.damage == 15)
        {
            if (textMaxDamage != null)
                textMaxDamage.SetActive(true);
        }

        textNextUpgradeDamage.GetComponent<Text>().text = String.Format(upgrade, costoPerMiglioramentoDamage.ToString());
        #endregion

        #region CollisionResistance 
        var costoPerMiglioramentoCollisionResistance = GenericService.GetCostoCollisionResistance()[collisionResistance + 1];

        if (textDescriptionCollisionResistance != null)
            textDescriptionCollisionResistance.GetComponent<Text>().text = "Resistenza a " + this.collisionResistance + " collisioni.";

        if (this.collisionResistance == 4)
        {
            if (textMaxCollisionResistance != null)
                textMaxCollisionResistance.SetActive(true);
        }

        textNextUpgradeCollisionResistance.GetComponent<Text>().text = String.Format(upgrade, costoPerMiglioramentoCollisionResistance.ToString());
        #endregion
    }

    public string GetRecapAbility()
    {
        return spawnRate + ";" + damage + ";" + collisionResistance; 
    }

    #region Upgrade
    public void UpgradeSpawnRate()
    {
        var costoPerMiglioramento = GenericService.GetCostoSpawnRate();

        if(spawnRate > 0.6F)
        {
            var costoTmp = costoPerMiglioramento[Mathf.FloorToInt((spawnRate * 10) - 1)];
            if(coins >= costoTmp)
            {
                coins -= costoTmp;
                spawnRate -= 0.1f;
                SaveAbility();
            }
            else
            {
                alertCoins.SetActive(true);
            }
        }


    }

    public void UpgradeDamage()
    {
        var costoPerMiglioramento = GenericService.GetCostoDamage();

        if (damage < 15)
        {
            var costoTmp = costoPerMiglioramento[damage + 1];
            if (coins >= costoTmp)
            {
                coins -= costoTmp;
                damage++;
                SaveAbility();
            }
            else
            {
                alertCoins.SetActive(true);
            }
        }

    }

    public void UpgradeCollisionResistance()
    {
        var costoPerMiglioramento = GenericService.GetCostoCollisionResistance();

        if (collisionResistance < 4)
        {
            var costoTmp = costoPerMiglioramento[collisionResistance + 1];
            if (coins >= costoTmp)
            {
                coins -= costoTmp;
                collisionResistance++;
                SaveAbility();
            }
            else
            {
                alertCoins.SetActive(true);
            }
        }

    }
    #endregion

    private void SaveAbility()
    {
        ss.SaveAbility(this);
        ss.SaveCoins(coins, false);
    }

    public void LoadAbility()
    {
        var data = ss.LoadAbility();

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
