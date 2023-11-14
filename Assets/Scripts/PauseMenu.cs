using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] GameObject pauseMenu;
    public void Pause()
    {
        pauseMenu.SetActive(true);
        GameController.isPause = true;
    }

    public void Home()
    {
        SceneManager.LoadScene("Home");
        GameController.isPause = false;
    }

    public void Resume()
    {
        pauseMenu.SetActive(false);
        GameController.isPause = false;
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        GameController.isPause = false;
    }
}
