using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RogueController : MonoBehaviour
{
    public float velocidade = 10;
    Rigidbody2D fisica;
    void Start()
    {
        fisica = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        float movimentoH = Input.GetAxis("Horizontal");
        float movimentoV = Input.GetAxis("Vertical");
        fisica.velocity = new Vector2(movimentoH, movimentoV) * velocidade;
    }
}
