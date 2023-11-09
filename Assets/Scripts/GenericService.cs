using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public static class GenericService 
{
    private static int asteroideID = 0;
    private static Dictionary<int, int> punteggioAsteroidi = new Dictionary<int, int>();

    public static int GetID()
    {
        //aumento ogni volta l'ID prima di fare il return cos� � sempre diverso
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

    public static Dictionary<int, int> GetCostoSpawnRate()
    {
        //la chiave sar� la velocit� di sparo, che � univoca e il valore sar� il costo
        var valore = new Dictionary<int, int>
        {
            //parte da 1.5 (non calcolabile per il costo) e arriva fino a 0.5
            //uso (spawnRate * 10) come chiave per comodit�
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
        //la chiave sar� il danno, che � univoca e il valore sar� il costo
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
        //la chiave sar� la resistenza alle collisioni, che � univoca e il valore sar� il costo
        var valore = new Dictionary<int, int>
        {
            //parte da 1 (non calcolabile per il costo) e arriva fino a 4
            { 2, 300 },
            { 3, 450 },
            { 4, 700 }
        };

        return valore;
    }

}
