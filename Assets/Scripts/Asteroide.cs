using TMPro;
using Unity.IO.LowLevel.Unsafe;
using UnityEngine;

public class Asteroide : MonoBehaviour
{

    public TextMeshPro punteggio;
    bool set;
    Vector3 customScale;

    // Start is called before the first frame update
    void Start()
    {
        set = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(!GameController.gameover)
        {
            if (!set)
            {
                set = true;
                var valore = Random.Range(1, 100);
                punteggio.text = valore.ToString();

                customScale = transform.localScale;

                if (valore < 25)
                {
                    customScale.x = 1.5f;
                    customScale.y = 1.5f;
                    punteggio.fontSize = 2.5f;
                }
                else if (valore >= 25 && valore < 65)
                {
                    customScale.x = 2f;
                    customScale.y = 2f;
                    punteggio.fontSize = 2.5f;
                }
                else
                {
                    customScale.x = 2.5f;
                    customScale.y = 2.5f;
                    punteggio.fontSize = 3;
                }

                transform.localScale = customScale;
            }

            transform.position = new Vector2(transform.position.x, transform.position.y - 0.025f);

        }

        if (transform.position.y <= -6)
            Destroy(gameObject);
    }
}
