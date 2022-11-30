using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private void Start()
    {
        if (gameObject != null)
            Invoke("DestroyGO", 5);
    }
    private void DestroyGO()
    {
        Destroy(gameObject);
    }
}
