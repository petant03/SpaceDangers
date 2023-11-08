using UnityEngine;

public class PlayerController : MonoBehaviour
{
    float deltaX, deltaY;
    Rigidbody2D rb;
    public GameObject restart;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(!GameController.gameover)
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

    public void OnCollisionEnter2D(Collision2D collision)
    {
        var obj = collision.gameObject.GetComponent<Asteroide>();

        if (obj != null)
        {
            GameController.gameover = true;
            restart.SetActive(true);
        }
        else
            Destroy(collision.gameObject);

    }
}
