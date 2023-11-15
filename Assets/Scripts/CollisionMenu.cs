using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionMenu : MonoBehaviour
{
    public void Home()
    {
        SceneManager.LoadScene("Home");
        GameController.gameover = false;
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        GameController.gameover = false;
    }
}
