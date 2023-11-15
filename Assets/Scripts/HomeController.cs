using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HomeController : MonoBehaviour
{
    private SaveLoadSystem ss;
    public Text best;
    public Text avg;

    private void Start()
    {
        ss = new SaveLoadSystem();
    }

    public void SetStats()
    {
        var bestString = "Miglior punteggio: {0}";
        var avgString = "Media asteroidi: {0}";
        var bestTmp = ss.LoadStats();

        if(bestTmp != null)
        {
            best.text = String.Format(bestString, bestTmp.Split(";")[0]);

            var avgAsteroidi = int.Parse(bestTmp.Split(";")[1]);
            var partite = int.Parse(bestTmp.Split(";")[2]);
            avg.text = String.Format(avgString, (avgAsteroidi/partite));
        }
        else
        {
            best.text = String.Format(bestString, "0");
            avg.text = String.Format(avgString, "0");
        }

    }
}
