using System;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;
    private AudioManager audioManager;

    float spawnTime;
    private float spawnRate;
    public float bulletForce; //forza (velocit�) del proiettile

    private void Start()
    {
        var ss = new SaveLoadSystem();
        var ability = ss.LoadAbility();

        if (ability != null)
        {
            float tmp = int.Parse(ability.Split(';')[0]);
            float sr = tmp / 10;
            spawnRate = sr;
        }
        else
            spawnRate = 1.5F;
    }

    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if(!GameController.gameover)
        {
            if(!GameController.isPause)
            {
                spawnTime += Time.deltaTime;

                //PER MOBILE
                if (Input.touchCount > 0)
                {
                    if (spawnTime > spawnRate)
                    {
                        spawnTime -= spawnRate;
                        Shoot();
                    }
                }

                //PER PC
                //if (Input.GetMouseButtonDown(0))
                //{
                //    if (spawnTime > spawnRate)
                //    {
                //        spawnTime -= spawnRate;
                //        Shoot();
                //    }
                //}
            }
        }
    }

    void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        audioManager.PlaySFX(audioManager.shoot);
        rb.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);
    }
}
