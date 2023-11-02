using UnityEngine;

public class Shooting : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;

    float spawnTime;
    private float spawnRate; //tempo per spawn di ogni proiettile
    public float bulletForce; //forza (velocità) del proiettile


    private void Start()
    {
        var sa = gameObject.AddComponent<SpaceshipAbility>();
        spawnRate = sa.spawnRate;
    }

    // Update is called once per frame
    void Update()
    {
        if(!GameController.gameover)
        {
            spawnTime += Time.deltaTime;

            if (Input.touchCount > 0)
            {
                if (spawnTime > spawnRate)
                {
                    spawnTime -= spawnRate;
                    Shoot();
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
