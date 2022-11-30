using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public Transform[] firePoints;
    public GameObject bulletPrefab;
    public float bulletForce = 20f;
    public float reloadTime = 1f;
    private float time;

    private void Start()
    {
        time = reloadTime;
        reloadTime = 0f;
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.Mouse0) && reloadTime == 0f)
        {
            Shoot();
            reloadTime = time;
        }
        else reloadTime -= Time.deltaTime;

        if (reloadTime < 0)
            reloadTime = 0;
    }

    void Shoot()
    {
        for (int i = 0; i < firePoints.Length; i++)
        {
            GameObject bullet = Instantiate(bulletPrefab, firePoints[i].position, Quaternion.Euler(0, 0, 90));
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            rb.AddForce(firePoints[i].up * bulletForce, ForceMode2D.Impulse);
        }
    }
}
