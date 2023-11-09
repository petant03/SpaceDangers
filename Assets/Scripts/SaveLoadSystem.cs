using System;
using System.IO;
using UnityEngine;

public class SaveLoadSystem
{
    private readonly string pathAbility = Application.persistentDataPath + "/ability.csv";
    private readonly string pathCoins = Application.persistentDataPath + "/coins.csv";
    public void SaveAbility(SpaceshipAbility ability)
    {
        try
        {
            StreamWriter sw = new StreamWriter(pathAbility); //todo con encryption
            sw.Write(ability.GetRecapAbility());
            sw.Close();

        }
        catch (Exception e)
        {
            Debug.LogException(e);
        }
    }

    public string LoadAbility()
    {
        try
        {
            if (File.Exists(pathAbility))
            {
                StreamReader sr = new StreamReader(pathAbility); //todo con encryption
                var ability = sr.ReadLine();
                sr.Close();

                return ability;
            }
            else
                return null;
        }
        catch (Exception e)
        {
            Debug.LogException(e);
            return null;
        }
    }

    public void SaveCoins(int coins, bool afterGame = true)
    {
        try
        {
            string loadCoins = null;

            if (afterGame) //recupero le monete dal file solo se ho terminato la partita
                loadCoins = LoadCoins();

            if (loadCoins != null) //il file esiste e ho un valore già salvato precedentemente
            {
                var coinsTmp = int.Parse(loadCoins);
                StreamWriter sw = new StreamWriter(pathCoins); //todo con encryption
                var coinsTotal = coins + coinsTmp;
                sw.Write(coinsTotal);
                sw.Close();
            }
            else //il file non esiste, quindi lo creo da zero
            {
                StreamWriter sw = new StreamWriter(pathCoins); //todo con encryption
                sw.Write(coins);
                sw.Close();
            }

        }
        catch (Exception e)
        {
            Debug.LogException(e);
        }
    }

    public string LoadCoins()
    {
        try
        {
            if (File.Exists(pathCoins))
            {
                StreamReader sr = new StreamReader(pathCoins); //todo con encryption
                var coins = sr.ReadLine();
                sr.Close();

                return coins;
            }
            else
                return null;
        }
        catch (Exception e)
        {
            Debug.LogException(e);
            return null;
        }
    }
}
