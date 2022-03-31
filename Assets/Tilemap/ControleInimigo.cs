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

    [Header("Sobre ver o player:")]
    [Range(0,20)]
    public float distanciaVisao = 5;
    Transform vouSeguir;
    public float distanciaDoPlayer = 1;
    //Variável para definirmos qual é a layer que o inimigo vai procurar
    public LayerMask layerDoPlayer;

    public float tempoParaPerderOPlayer = 3;
    float contadorDeTempo;

    void Start()
    {
        fisica = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        //Procura um ponto
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
        //Normalizar deixa no mínimo -1 e no máximo 1
        direcao.Normalize();

        //Já vi o player?
        if (vouSeguir != null)
        {
            //Mudar minha direção para seguir o player
            direcao = vouSeguir.position - transform.position;
            direcao.Normalize();

            
        }

        //Criar uma linha e ver se o player está nela
        Debug.DrawRay(transform.position, direcao * distanciaVisao, Color.red);
        //Raycast desenha um raio invisível que colide com quem tiver um Collider
        RaycastHit2D bateu = 
            Physics2D.Raycast(transform.position, direcao, distanciaVisao,layerDoPlayer);
        if (bateu.collider)
        {
            Debug.Log("Eu bati no " + bateu.collider);
            vouSeguir = bateu.collider.transform;
            contadorDeTempo = tempoParaPerderOPlayer;
        }
        else
        {
            Debug.Log("Não bati em ninguém =(");
            if (vouSeguir)
            {
                //Time.deltaTime é igual a quantidade de tempo que demorou
                //Entre um quadro e outro. Se tiver a 60fps, é 1/60
                contadorDeTempo -= Time.deltaTime;
                if(contadorDeTempo <= 0)
                {
                    vouSeguir = null;
                }
            }
        }

        if (vouSeguir)
        {
            float distanciaAtual =
                Vector2.Distance(transform.position, vouSeguir.position);
            if (distanciaAtual <= distanciaDoPlayer)
            {
                direcao = Vector2.zero;
            }
        }

        //E manda andar na direção
        fisica.velocity = direcao * velocidade;
    }
}
