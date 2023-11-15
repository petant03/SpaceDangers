using System;
using System.IO;
using UnityEngine;

public class SaveLoadSystem
{
    private readonly string pathAbility = Application.persistentDataPath + "/ability.csv";
    private readonly string pathCoins = Application.persistentDataPath + "/coins.csv";
    private readonly string pathStats = Application.persistentDataPath + "/stats.csv";

    #region Ability
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
    #endregion

    #region Coins
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
    #endregion

    #region Stats
    public void SaveStats()
    {
        try
        {
            string loadStats = LoadStats();

            if (loadStats != null) //il file esiste e ho un valore già salvato precedentemente
            {
                //0 => best
                //1 => partite fatte
                //2 => totaleAsteroidi
                var statsSplit = loadStats.Split(';');

                //recupero il valore più alto degli asteroidi
                var bestTmp = int.Parse(statsSplit[0]);
                var partite = int.Parse(statsSplit[1]);
                var totalAsteroidi = int.Parse(statsSplit[2]);

                //confronto e salvo solo se maggiore
                if (GenericService.GetCountAsteroidi() > bestTmp)
                {
                    StreamWriter sw = new StreamWriter(pathStats); //todo con encryption
                    
                    //il 2 sarà da sostituire con il numero di partite fatte
                    var s = String.Format("{0};{1};{2}", GenericService.GetCountAsteroidi(), 2, (totalAsteroidi + GenericService.GetCountAsteroidi()));

                    sw.Write(s);
                    sw.Close();
                }
                else
                {
                    StreamWriter sw = new StreamWriter(pathStats); //todo con encryption

                    //il 2 sarà da sostituire con il numero di partite fatte
                    var s = String.Format("{0};{1};{2}", bestTmp, 2, (totalAsteroidi + GenericService.GetCountAsteroidi()));

                    sw.Write(s);
                    sw.Close();
                }
            }
            else //il file non esiste, quindi lo creo da zero
            {
                StreamWriter sw = new StreamWriter(pathStats); //todo con encryption
                sw.Write(GenericService.GetCountAsteroidi());
                sw.Close();
            }

            GenericService.ResetCountAsteroidi();

        }
        catch (Exception e)
        {
            Debug.LogException(e);
        }
    }

    public string LoadStats()
    {
        try
        {
            if (File.Exists(pathStats))
            {
                StreamReader sr = new StreamReader(pathStats); //todo con encryption
                var stats = sr.ReadLine();
                sr.Close();

                return stats;
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
    #endregion
}
