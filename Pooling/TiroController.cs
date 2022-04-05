using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TiroController : MonoBehaviour
{
    public float velocidade = 10;
    Rigidbody2D fisica;

    void Start()
    {
        fisica = GetComponent<Rigidbody2D>();
        Invoke("MeDestroi", 5);
    }

    void Update()
    {
        fisica.velocity = new Vector2(0, velocidade);
    }

    void MeDestroi()
    {
        Destroy(gameObject);
    }
}
