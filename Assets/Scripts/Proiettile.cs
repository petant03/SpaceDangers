using TMPro;
using UnityEngine;

public class Proiettile : MonoBehaviour
{
    private int damage;

    private void Update()
    {
        if(transform.position.y > 7)
            Destroy(gameObject);
    }

    //public GameObject hitEffect;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(!GameController.gameover)
        {
            //GameObject effect = Instantiate(hitEffect, transform.position, Quaternion.identity);
            //Destroy(effect, 5f);

            var sa = gameObject.AddComponent<SpaceshipAbility>();
            damage = sa.damage;

            int punti = int.Parse(collision.gameObject.GetComponentInChildren<TextMeshPro>().text);

            if (punti > 1)
            {
                punti -= damage;

                if(punti <= 0)
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
