using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    [SerializeField] GameObject collisionMenu;
    float deltaX, deltaY;
    Rigidbody2D rb;
    SpriteRenderer sr;
    public Text punteggio;

    private SaveLoadSystem ss;
    private int collisionResistance;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        ss = new SaveLoadSystem();

        var crTmp = ss.LoadAbility();
        collisionResistance = crTmp != null ? int.Parse(crTmp.Split(";")[2]) : 1;
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
            collisionResistance--;
            
            if (collisionResistance >= 0)
            {
                //fading e continuo il gioco
                Destroy(collision.gameObject);

                InitFaiding();
            }
            else
            {
                //gioco finito
                GameController.gameover = true;
                punteggio.text = "Punteggio: " + GenericService.GetCountAsteroidi();
                collisionMenu.SetActive(true);
                ss.SaveStats();
            }

        }
        else
            Destroy(collision.gameObject);
    }

    private void InitFaiding()
    {
        StartCoroutine("FadeOut");
        StartCoroutine("FadeIn");
    }

    IEnumerator FadeIn()
    {
        for(float f = 0.05f; f <= 1; f += 0.05f)
        {
            Color c = sr.material.color;
            c.a = f;
            sr.material.color = c;
            yield return new WaitForSeconds(0.05f);
        }
    }

    IEnumerator FadeOut()
    {
        for(float f = 1f; f >= 0.05f; f -= 0.05f)
        {
            Color c = sr.material.color;
            c.a = f;
            sr.material.color = c;
            yield return new WaitForSeconds(0.05f);
        }
    }
}
