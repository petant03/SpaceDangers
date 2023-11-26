using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public static class GenericService 
{
    private static int asteroideID = 0;
    private static Dictionary<int, int> punteggioAsteroidi = new Dictionary<int, int>();
    private static Dictionary<int, int> costoSpawnRate;
    private static Dictionary<int, int> costoDamage;
    private static Dictionary<int, int> costoCollisionResistance;
    private static int countAsteroidi = 0;
    private static float totalGameTime = 0;

    #region Asteroide
    public static int GetID()
    {
        //aumento ogni volta l'ID prima di fare il return così è sempre diverso
        asteroideID++;
        return asteroideID;
    }

    public static int GetPunteggioByID(int id)
    {
        return punteggioAsteroidi[id];
    }

    public static void SetPunteggio(int id, int punteggio)
    {
        punteggioAsteroidi.Add(id, punteggio);
    }
    #endregion

    #region Upgrade
    public static void SetCostoSpawnRate()
    {
        //la chiave sarà la velocità di sparo, che è univoca e il valore sarà il costo
        costoSpawnRate = new Dictionary<int, int>
        {
            //parte da 1.5 (non calcolabile per il costo) e arriva fino a 0.5
            //uso (spawnRate * 10) come chiave per comodità
            { 14, 50 },
            { 13, 100 },
            { 12, 150 },
            { 11, 200 },
            { 10, 250 },
            { 9, 300 },
            { 8, 350 },
            { 7, 400 },
            { 6, 450 },
            { 5, 500 }
        };
    }

    public static void SetCostoDamage()
    {
        //la chiave sarà il danno, che è univoca e il valore sarà il costo
        costoDamage = new Dictionary<int, int>
        {
            //parte da 1 (non calcolabile per il costo) e arriva fino a 15
            { 2, 25 },
            { 3, 50 },
            { 4, 75 },
            { 5, 100 },
            { 6, 150 },
            { 7, 200 },
            { 8, 250 },
            { 9, 300 },
            { 10, 350 },
            { 11, 400 },
            { 12, 450 },
            { 13, 500 },
            { 14, 550 },
            { 15, 600 }
        };
    }

    public static void SetCostoCollisionResistance()
    {
        //la chiave sarà la resistenza alle collisioni, che è univoca e il valore sarà il costo
        costoCollisionResistance = new Dictionary<int, int>
        {
            //parte da 1 (non calcolabile per il costo) e arriva fino a 3
            { 1, 300 },
            { 2, 450 },
            { 3, 700 }
        };
    }

    public static Dictionary<int, int> GetCostoSpawnRate()
    {
        return costoSpawnRate;
    }

    public static Dictionary<int, int> GetCostoDamage()
    {
        return costoDamage;
    }

    public static Dictionary<int, int> GetCostoCollisionResistance()
    {
        return costoCollisionResistance;
    }
    #endregion

    #region Stats
    public static void AumentaCountAsteroidi()
    {
        countAsteroidi++;
    }

    public static int GetCountAsteroidi()
    {
        return countAsteroidi;
    }

    public static void ResetCountAsteroidi()
    {
        countAsteroidi = 0;
    }
    #endregion

    public static void SetTotalGameTime(float value)
    {
        totalGameTime += value;
    }

    public static float GetTotalGameTime()
    {
        return totalGameTime;
    }

    public static void ResetTotalGameTime()
    {
        totalGameTime = 0;
    }
}
