using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BottomBar : MonoBehaviour
{
    public void StartGame()
    {
        var ss = new SaveLoadSystem();
        ss.SaveStats(true);
        SceneManager.LoadScene("Game");
    }

    public void Shop()
    {
        SceneManager.LoadScene("Shop");
    }

    public void Upgrade()
    {
        SceneManager.LoadScene("Upgrade");
    }
}
