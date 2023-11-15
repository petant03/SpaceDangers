using System;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;

    float spawnTime;
    private float spawnRate;
    public float bulletForce; //forza (velocità) del proiettile

    private void Start()
    {
        var ss = new SaveLoadSystem();
        var ability = ss.LoadAbility();

        spawnRate = ability != null ? float.Parse(ability.Split(';')[0]) : 1.5F;
    }

    // Update is called once per frame
    void Update()
    {
        if(!GameController.gameover)
        {
            if(!GameController.isPause)
            {
                spawnTime += Time.deltaTime;

                //if (Input.touchCount > 0)
                //{
                //    if (spawnTime > spawnRate)
                //    {
                //        spawnTime -= spawnRate;
                //        Shoot();
                //    }
                //}

                if (Input.GetMouseButtonDown(0))
                {
                    if (spawnTime > spawnRate)
                    {
                        spawnTime -= spawnRate;
                        Shoot();
                    }
                }
            }
        }
    }

    void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);
    }
}
