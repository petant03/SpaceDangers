using TMPro;
using UnityEngine;

public class Proiettile : MonoBehaviour
{
    private int damage;

    private SaveLoadSystem ss;
    private AudioManager audioManager;

    private void Start()
    {
        ss = new SaveLoadSystem();
        var ability = ss.LoadAbility();

        damage = ability != null ? int.Parse(ability.Split(';')[1]) : 1;
    }

    private void Update()
    {
        if (transform.position.y > 7)
            Destroy(gameObject);
    }

    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!GameController.gameover)
        {
            if(!GameController.isPause)
            {
                audioManager.PlaySFX(audioManager.hitEffect);

                int punti = int.Parse(collision.gameObject.GetComponentInChildren<TextMeshPro>().text);

                if (punti > 1)
                {
                    punti -= damage;

                    if (punti <= 0)
                        DestroyAsteroide(collision.gameObject);
                    else
                        collision.gameObject.GetComponentInChildren<TextMeshPro>().text = punti.ToString();

                }
                else
                    DestroyAsteroide(collision.gameObject);

                Destroy(gameObject);
            }
        }
    }

    private void DestroyAsteroide(GameObject go)
    {
        var asteroideID = go.GetComponent<Asteroide>().GetID();
        var valore = GenericService.GetPunteggioByID(asteroideID);
        GenericService.AumentaCountAsteroidi();
        ss.SaveCoins(valore);
        audioManager.PlaySFX(audioManager.explosion);
        Destroy(go);
    }
}
