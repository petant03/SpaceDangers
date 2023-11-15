using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    [SerializeField] GameObject collisionMenu;
    float deltaX, deltaY;
    Rigidbody2D rb;
    public Text punteggio;
    private SaveLoadSystem ss;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        ss = new SaveLoadSystem();
    }

    // Update is called once per frame
    void Update()
    {
        if(!GameController.gameover)
        {
            if(!GameController.isPause)
            {
                if (Input.touchCount > 0)
                {
                    Touch t = Input.GetTouch(0);
                    Vector2 touchPos = Camera.main.ScreenToWorldPoint(t.position);

                    switch (t.phase)
                    {
                        case TouchPhase.Began:
                            deltaX = touchPos.x - transform.position.x;
                            deltaY = touchPos.y - transform.position.y;
                            break;

                        case TouchPhase.Moved:
                            rb.MovePosition(new Vector2(touchPos.x - deltaX, touchPos.y - deltaY));
                            break;

                        case TouchPhase.Ended:
                            rb.velocity = Vector2.zero;
                            break;
                    }
                }
            }
        }
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        var obj = collision.gameObject.GetComponent<Asteroide>();

        if (obj != null)
        {
            GameController.gameover = true;
            punteggio.text = "Punteggio: " + GenericService.GetCountAsteroidi();
            collisionMenu.SetActive(true);
            ss.SaveStats();
        }
        else
            Destroy(collision.gameObject);

    }
}
