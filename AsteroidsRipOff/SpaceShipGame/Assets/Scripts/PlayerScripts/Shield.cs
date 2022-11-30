using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour
{
    public ShieldBar shieldBar;
    public Animator animator;
    public float ShieldingTime;
    public float ShieldReloadTime = 3f;
    [HideInInspector] public bool isShielded = false;
    private float time;

    private void Start()
    {
        shieldBar.MaxShielCD(ShieldReloadTime);
        time = ShieldReloadTime;
        ShieldReloadTime = 0f;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && ShieldReloadTime == 0)
        {
            ShieldReloadTime = time;
            isShielded = true;
            animator.SetBool("isShielded", true);
            Invoke("ResetShielding", ShieldingTime);
        }
        else
        {
            ShieldReloadTime -= Time.deltaTime;
            shieldBar.ShieldCD(ShieldReloadTime);
        }
        if (ShieldReloadTime < 0)
        {
            ShieldReloadTime = 0;
            shieldBar.ShieldCD(ShieldReloadTime);
        }
    }

    public void ResetShielding()
    {
        isShielded = false;
        animator.SetBool("isShielded", false);
    }
}