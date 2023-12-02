using System;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[System.Serializable]
public class SpaceshipAbility : MonoBehaviour
{
    private SaveLoadSystem ss;

    private int coins;
    private const string upgrade = "Il prossimo miglioramento costa {0} monete.";
    private const string max = "Hai raggiunto il livello massimo!";

    [Header("--- Spawn Rate ---")]
    public Text descriptionSpawnRate;
    public Text nextUpgradeSpawnRate;
    public Text txtBtnSpawnRate;

    [Header("--- Damage ---")]
    public Text descriptionDamage;
    public Text nextUpgradeDamage;
    public Text txtBtnDamage;

    [Header("--- Resistance ---")]
    public Text descriptionCollisionResistance;
    public Text nextUpgradeCollisionResistance;
    public Text txtBtnCollisionResistance;

    [Header("--- Ability ---")]
    public int spawnRate;
    public int damage;
    public int collisionResistance;

    [Header("--- Alert ---")]
    public GameObject alert;

    private int costoPerMiglioramentoSpawnRate = 0;
    private int costoPerMiglioramentoDamage = 0;
    private int costoPerMiglioramentoCollisionResistance = 0;

    private void Start()
    {
        ss = new SaveLoadSystem();
        coins = ss.LoadCoins() != null ? int.Parse(ss.LoadCoins()) : 0;
        LoadAbility();
    }

    public void Update()
    {
        #region SpawnRate
        if (this.spawnRate > 5)
            costoPerMiglioramentoSpawnRate = GenericService.GetCostoSpawnRate()[spawnRate - 1];
        
        if (descriptionSpawnRate != null)
            descriptionSpawnRate.text = "Spara un proiettile ogni " + ((float)this.spawnRate / 10).ToString("F2") + " secondi.";

        if (descriptionSpawnRate != null)
        {
            if (this.spawnRate > 5)
                nextUpgradeSpawnRate.text = String.Format(upgrade, costoPerMiglioramentoSpawnRate.ToString());
            else
            {
                nextUpgradeSpawnRate.text = max;
                nextUpgradeSpawnRate.color = Color.red;
                nextUpgradeSpawnRate.fontStyle = FontStyle.Bold;
                txtBtnSpawnRate.color = Color.red;
                txtBtnSpawnRate.fontStyle = FontStyle.Bold;
            }
        }
        #endregion

        #region Damage
        if(this.damage < 15)
            costoPerMiglioramentoDamage = GenericService.GetCostoDamage()[damage + 1];

        if (descriptionDamage != null)
            descriptionDamage.text = "Un proiettile infligge " + this.damage + " danni.";

        if (descriptionDamage != null)
        {
            if (this.damage < 15)
                nextUpgradeDamage.text = String.Format(upgrade, costoPerMiglioramentoDamage.ToString());
            else
            {
                nextUpgradeDamage.text = max;
                nextUpgradeDamage.color = Color.red;
                nextUpgradeDamage.fontStyle = FontStyle.Bold;
                txtBtnDamage.color = Color.red;
                txtBtnDamage.fontStyle = FontStyle.Bold;
            }
        }
        #endregion

        #region CollisionResistance 
        if (this.collisionResistance < 3)
            costoPerMiglioramentoCollisionResistance = GenericService.GetCostoCollisionResistance()[collisionResistance + 1];

        if (descriptionCollisionResistance != null)
            descriptionCollisionResistance.text = "Resistenza a " + this.collisionResistance + " collisioni.";

        if (descriptionCollisionResistance != null)
        {
            if (this.collisionResistance < 3)
                nextUpgradeCollisionResistance.text = String.Format(upgrade, costoPerMiglioramentoCollisionResistance.ToString());
            else
            {
                nextUpgradeCollisionResistance.text = max;
                nextUpgradeCollisionResistance.color = Color.red;
                nextUpgradeCollisionResistance.fontStyle = FontStyle.Bold;
                txtBtnCollisionResistance.color = Color.red;
                txtBtnCollisionResistance.fontStyle = FontStyle.Bold;
            }
        }
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

        if (spawnRate >= 6)
        {
            var costoTmp = costoPerMiglioramento[spawnRate - 1];
            if (coins >= costoTmp)
            {
                coins -= costoTmp;
                spawnRate -= 1;
                SaveAbility();
            }
            else
                alert.SetActive(true);
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
                alert.SetActive(true);
        }

    }

    public void UpgradeCollisionResistance()
    {
        var costoPerMiglioramento = GenericService.GetCostoCollisionResistance();

        if (collisionResistance < 3)
        {
            var costoTmp = costoPerMiglioramento[collisionResistance + 1];
            if (coins >= costoTmp)
            {
                coins -= costoTmp;
                collisionResistance++;
                SaveAbility();
            }
            else
                alert.SetActive(true);
        }

    }
    #endregion

    #region Save
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
            spawnRate = int.Parse(data.Split(';')[0]);
            damage = int.Parse(data.Split(';')[1]);
            collisionResistance = int.Parse(data.Split(';')[2]);
        }
        else
        {
            spawnRate = 15;
            damage = 1;
            collisionResistance = 0;
        }
    }
    #endregion

    #region Alert
    public void GoToShop()
    {
        SceneManager.LoadScene("Shop");
    }

    public void Play()
    {
        SceneManager.LoadScene("Game");
    }
    #endregion
}
