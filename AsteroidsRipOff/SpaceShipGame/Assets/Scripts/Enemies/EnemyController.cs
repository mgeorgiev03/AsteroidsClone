using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float VerticalSpeed = 14;
    public float HorizontalSpeed = 5;
    public float SeePlayerFromDistance = 14;

    [HideInInspector] public bool shoot = true;
    private EnemyShooting enemyShooting;
    private Rigidbody2D rb;
    private GameObject player;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player");
        enemyShooting = GetComponent<EnemyShooting>();  
    }

    private void Update()
    {
        if (Vector2.Distance(player.transform.position, transform.position) < SeePlayerFromDistance)
        {
            if (Mathf.Abs(transform.position.y) - Mathf.Abs(player.transform.position.y) <= 10)
            {
                shoot = true;
            }
            //else
            //{
            //    Debug.Log("pain");
            //    if (transform.position.x > player.transform.position.x)
            //        transform.Translate(transform.position - new Vector3(transform.position.x, transform.position.y + (VerticalSpeed * Time.deltaTime)));
            //}
        }
        else 
            transform.Translate(transform.position - new Vector3(transform.position.x, transform.position.y + (HorizontalSpeed * Time.deltaTime)));
    }
}
