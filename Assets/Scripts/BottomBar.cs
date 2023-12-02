using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BottomBar : MonoBehaviour
{
    public void Home()
    {
        SceneManager.LoadScene("Home");
        GenericService.SetFromBottomBar(true);
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
