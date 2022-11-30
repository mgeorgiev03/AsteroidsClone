using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    public HealthBar healthBar;
    public int HP = 100;
    public float VerticalSpeed = 5f;
    public float HorizontalSpeed = 2.5f;
    public float SmoothDamp;

    private Animator animator;
    private Rigidbody2D rb;
    private Vector2 movement;
    private Vector3 m_Velocity = Vector3.zero;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        healthBar.MaxHealth(HP);
    }

    private void Update()
    {
        movement.y = Input.GetAxisRaw("Vertical") * VerticalSpeed;
        movement.x = Input.GetAxisRaw("Horizontal") * HorizontalSpeed;
        animator.SetFloat("Velocity", rb.velocity.x);

        if (Input.GetKeyDown(KeyCode.R))
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private void FixedUpdate()
    {
        rb.velocity = Vector3.SmoothDamp(rb.velocity, movement, ref m_Velocity, SmoothDamp);
    }

    public void TakeDamage(int damage)
    {
        if (!GetComponent<Shield>().isShielded)
        {
            HP -= damage;
            healthBar.Heath(HP);
            if (HP == 0)
                Die();
        }
    }

    private void Die()
    {
        //anim + death menu
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
