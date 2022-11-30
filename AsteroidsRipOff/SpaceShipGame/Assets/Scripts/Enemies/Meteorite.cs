using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Meteorite : MonoBehaviour
{
    public float spawnForceX;
    public float spawnForceY;
    public int HP = 6;

    private void Start()
    {
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        rb.AddForce(new Vector2(spawnForceX, spawnForceY) * new Vector2(Random.Range(0.2f, 1.8f), 1f), ForceMode2D.Impulse);
        if (gameObject != null)
            Invoke("DestroyMeteorite", 15f);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (CompareTag("SmallM"))
            {
                collision.gameObject.GetComponent<PlayerMovement>().TakeDamage(3);
                collision.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(2f, 2f));
                DestroyMeteorite();
            }
            else if (CompareTag("MedM"))
            {
                collision.gameObject.GetComponent<PlayerMovement>().TakeDamage(6);
                collision.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(4f, 2f));
                DestroyMeteorite();
            }
            else if (CompareTag("BigM"))
            {
                collision.gameObject.GetComponent<PlayerMovement>().TakeDamage(9);
                collision.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(6f, 2f));
                DestroyMeteorite();
            }
            collision.gameObject.GetComponent<Shield>().ResetShielding();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        OnTrigger(collision);
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        OnTrigger(collision);
    }

    private void OnTrigger(Collider2D collision)
    {
        if (collision.CompareTag("Bullet"))
        {
            Destroy(collision.gameObject);
            TakeDamage(1);
        }
    }
    public void TakeDamage(int damage)
    {
        HP-=damage;
        if (HP == 0)
            DestroyMeteorite();
    }

    private void DestroyMeteorite()
    {
        //anim
        Destroy(gameObject);
    }
}
