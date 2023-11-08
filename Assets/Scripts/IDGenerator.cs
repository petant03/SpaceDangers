using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public static class IDGenerator 
{
    private static int ID = 0;
    public static Dictionary<int, int> punteggioAsteroidi = new Dictionary<int, int>();

    public static int GetID()
    {
        //aumento ogni volta l'ID prima di fare il return così è sempre diverso
        ID++;
        return ID;
    }

}
