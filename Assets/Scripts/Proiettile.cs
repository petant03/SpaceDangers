using TMPro;
using UnityEngine;

public class Proiettile : MonoBehaviour
{
    private int damage;
    //public GameObject hitEffect;

    private SaveLoadSystem ss;

    private void Start()
    {
        ss = new SaveLoadSystem();
        var ability = ss.LoadAbility();

        //damage = ability != null ? int.Parse(ability.Split(';')[1]) : 1;

        damage = 50;
    }

    private void Update()
    {
        if (transform.position.y > 7)
            Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!GameController.gameover)
        {
            //GameObject effect = Instantiate(hitEffect, transform.position, Quaternion.identity);
            //Destroy(effect, 5f);

            int punti = int.Parse(collision.gameObject.GetComponentInChildren<TextMeshPro>().text);

            if (punti > 1)
            {
                punti -= damage;

                if (punti <= 0)
                    DestroyProiettile(collision.gameObject);
                else
                    collision.gameObject.GetComponentInChildren<TextMeshPro>().text = punti.ToString();

            }
            else
                DestroyProiettile(collision.gameObject);

            Destroy(gameObject);
        }
    }

    private void DestroyProiettile(GameObject go)
    {
        var asteroideID = go.GetComponent<Asteroide>().GetID();
        var valore = GenericService.GetPunteggioByID(asteroideID);
        ss.SaveCoins(valore);
        Destroy(go);
    }
}
