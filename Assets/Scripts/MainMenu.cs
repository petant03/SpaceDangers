using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    private void Start()
    {
        InitCosti();
        ControlPrefs();
    }

    public void PlayGame()
    {
        SceneManager.LoadScene("Home");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    private void ControlPrefs()
    {
        if(PlayerPrefs.HasKey("50Monete"))
        {
            PlayerPrefs.DeleteKey("50Monete");
            PlayerPrefs.SetInt("50Monete", 0); //servono due video per ottenere la ricompensa
        }

        if (PlayerPrefs.HasKey("75Monete"))
        {
            PlayerPrefs.DeleteKey("75Monete");
            PlayerPrefs.SetInt("75Monete", 0); //servono tre video per ottenere la ricompensa
        }

        if (PlayerPrefs.HasKey("100Monete"))
        {
            PlayerPrefs.DeleteKey("100Monete");
            PlayerPrefs.SetInt("100Monete", 0); //servono quattro video per ottenere la ricompensa
        }
    }

    private void InitCosti()
    {
        GenericService.SetCostoSpawnRate();
        GenericService.SetCostoDamage();
        GenericService.SetCostoCollisionResistance();
    }
}
