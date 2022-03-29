using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControleInimigo : MonoBehaviour
{
    Rigidbody2D fisica;
    public float velocidade = 5;

    public Transform[] pontos;
    int pontoAtual = 0;

    public float distanciaAceitavel = 0.5f;
    void Start()
    {
        fisica = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        Vector2 direcao = pontos[pontoAtual].position - transform.position;
        float distancia =
            Vector2.Distance(transform.position, pontos[pontoAtual].position);
        if (distancia <= distanciaAceitavel)
        {
            pontoAtual = pontoAtual + 1;
            if(pontoAtual >= pontos.Length)
            {
                pontoAtual = 0;
            }
        }

        direcao.Normalize();
        fisica.velocity = direcao * velocidade;
    }
}
