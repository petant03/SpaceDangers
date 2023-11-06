using TMPro;
using UnityEngine;

public class Proiettile : MonoBehaviour
{
    private int damage;
    //public GameObject hitEffect;

    private void Start()
    {
        var ss = new SaveLoadSystem();
        var ability = ss.LoadAbility();
        damage = int.Parse(ability.Split(';')[1]);
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
                    Destroy(collision.gameObject);
                else
                    collision.gameObject.GetComponentInChildren<TextMeshPro>().text = punti.ToString();

            }
            else
                Destroy(collision.gameObject);

            Destroy(gameObject);
        }
    }
}
