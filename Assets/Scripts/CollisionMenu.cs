using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionMenu : MonoBehaviour
{
    public void Home()
    {
        SceneManager.LoadScene("Home");
        GameController.gameover = false;
        GenericService.ResetTotalGameTime();
        GenericService.SetAfterGame(true);
    }

    public void Restart()
    {
        var ss = new SaveLoadSystem();
        ss.SaveStats(true);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        GameController.gameover = false;
        GenericService.ResetTotalGameTime();
        GenericService.SetAfterGame(true);
    }
}
