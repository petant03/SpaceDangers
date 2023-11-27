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
        PlayerPrefs.SetInt("50Monete", 0); //servono due video per ottenere la ricompensa
        PlayerPrefs.SetInt("75Monete", 0); //servono tre video per ottenere la ricompensa
        PlayerPrefs.SetInt("100Monete", 0); //servono quattro video per ottenere la ricompensa
    }

    private void InitCosti()
    {
        GenericService.SetCostoSpawnRate();
        GenericService.SetCostoDamage();
        GenericService.SetCostoCollisionResistance();
    }
}
