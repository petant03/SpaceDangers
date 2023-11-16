using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public static class GenericService 
{
    private static int asteroideID = 0;
    private static Dictionary<int, int> punteggioAsteroidi = new Dictionary<int, int>();
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
    public static Dictionary<int, int> GetCostoSpawnRate()
    {
        //la chiave sarà la velocità di sparo, che è univoca e il valore sarà il costo
        var valore = new Dictionary<int, int>
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

        return valore;
    }

    public static Dictionary<int, int> GetCostoDamage()
    {
        //la chiave sarà il danno, che è univoca e il valore sarà il costo
        var valore = new Dictionary<int, int>
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

        return valore;
    }

    public static Dictionary<int, int> GetCostoCollisionResistance()
    {
        //la chiave sarà la resistenza alle collisioni, che è univoca e il valore sarà il costo
        var valore = new Dictionary<int, int>
        {
            //parte da 1 (non calcolabile per il costo) e arriva fino a 4
            { 2, 300 },
            { 3, 450 },
            { 4, 700 }
        };

        return valore;
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
