using System;
using UnityEngine;

public class GameController : MonoBehaviour
{
    float spawnTime;
    private float spawnRate;
    public GameObject asteroide;
    public static bool gameover;
    public static bool isPause;

    // Start is called before the first frame update
    void Start()
    {
        gameover = false;
        isPause = false;
        spawnRate = 3f;

        GenericService.SetFromBottomBar(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (!gameover && !isPause)
        {
            spawnTime += Time.deltaTime;
            
            GenericService.SetTotalGameTime(Time.deltaTime * 15);

            var t = GenericService.GetTotalGameTime() / 25;

            if (t >= 0 && t <= 20)
                spawnRate = 2.5f;
            else if (t >= 21 && t <= 40)
                spawnRate = 2f;
            else if (t >= 41 && t <= 60)
                spawnRate = 1.5f;
            else if (t >= 61)
                spawnRate = 1f;

            if (spawnTime > spawnRate)
            {
                spawnTime -= spawnRate;
                Vector2 pos = new Vector2(UnityEngine.Random.Range(-2f, 2f), 6f);
                Instantiate(asteroide, pos, Quaternion.identity);
            }
        }
    }
}
