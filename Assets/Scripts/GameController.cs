using TMPro;
using UnityEngine;

public class GameController : MonoBehaviour
{
    float gameTime;
    float spawnTime;
    float spawnRate = 2f; //ogni 2.5 secondi
    public GameObject asteroide;
    public static bool gameover;
    public static bool isPause;

    // Start is called before the first frame update
    void Start()
    {
        gameover = false;
        isPause = false;
        gameTime = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(!gameover)
        {
            if(!isPause)
            {
                gameTime += Time.deltaTime;
                spawnTime += Time.deltaTime;
                GenericService.SetTotalGameTime(gameTime);

                if (spawnTime > spawnRate)
                {
                    spawnTime -= spawnRate;
                    Vector2 pos = new Vector2(Random.Range(-2f, 2f), 6f);
                    Instantiate(asteroide, pos, Quaternion.identity);
                }
            }
        }
    }
}
