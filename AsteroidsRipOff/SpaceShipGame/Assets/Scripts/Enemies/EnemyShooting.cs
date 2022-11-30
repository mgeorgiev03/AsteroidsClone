using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooting : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;
    public float FireRate;
    public float bulletForce;
    public float Damage;
    [HideInInspector] public bool shoot;

    public float reloadTime = 1f;
    private float time;

    private void Start()
    {
        time = reloadTime;
        reloadTime = 0f;
    }

    void Update()
    {
        if (shoot)
        {
            if (reloadTime == 0f)
            {
                Shoot();
                reloadTime = time;
            }
            else reloadTime -= Time.deltaTime;

            if (reloadTime < 0)
                reloadTime = 0;
        }
    }

    public void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, Quaternion.identity);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(-firePoint.up * bulletForce, ForceMode2D.Impulse);
    }
}
