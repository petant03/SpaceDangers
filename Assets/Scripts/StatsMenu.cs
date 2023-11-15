using UnityEngine;
using UnityEngine.SceneManagement;

public class StatsMenu : MonoBehaviour
{
    [SerializeField] GameObject statsMenu;
    public void Show()
    {
        statsMenu.SetActive(true);
    }

    public void Hide()
    {
        statsMenu.SetActive(false);
    }
}
