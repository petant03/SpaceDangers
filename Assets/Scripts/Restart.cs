using UnityEngine;
using UnityEngine.SceneManagement;

public class Restart : MonoBehaviour
{
    public void ClickRestart()
    {
        GameController.gameover = true;
        SceneManager.LoadScene("Game");
    }
}
