using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    private void Start()
    {
        Init();
    }

    public void PlayGame()
    {
        SceneManager.LoadScene("Home");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    private void Init()
    {
        InitCosti();
        ControlPrefs();

        GenericService.SetAfterGame(false);
        GenericService.SetFromBottomBar(false);
    }

    private void ControlPrefs()
    {
        PlayerPrefs.SetInt("AdsAfterGame", 0); 
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
