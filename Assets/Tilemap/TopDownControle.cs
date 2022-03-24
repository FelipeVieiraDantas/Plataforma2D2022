using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopDownControle : MonoBehaviour
{
    Rigidbody2D fisica;
    public float velocidade = 10;

    void Start()
    {
        fisica = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        float controleH = Input.GetAxisRaw("Horizontal");
        float controleV = Input.GetAxisRaw("Vertical");
        // normalized limita os valores para -1 e 1. Assim não fica mais rápido
        // andando na diagonal.
        fisica.velocity = new Vector2(controleH, controleV).normalized * velocidade;
    }
}
