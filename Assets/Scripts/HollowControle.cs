using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HollowControle : MonoBehaviour
{
    Rigidbody2D fisica;
    public float velocidade = 10;
    public float forcaPulo = 100;

    // Start is called before the first frame update
    void Start()
    {
        fisica = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //Get Axis Horizontal:
        //retorna -1 se o jogador apertar para esquerda
        //retorna 1 se o jogador apertar para direita
        //retorna 0 se o jogador não apertar nada
        float taApertando = Input.GetAxis("Horizontal");
        //Velocidade precisa de um Vector2. Ou seja:
        //Primeiro valor é X, horizontal
        //Segundo valor, depois da vírgula, é Y, vertical.
        fisica.velocity = new Vector2(
            taApertando * velocidade,
            fisica.velocity.y);

        //GetKeyDown retorna verdadeiro (true) se o jogador
        //acabou de apertar uma tecla. No caso, espaço
        bool pulei = Input.GetKeyDown(KeyCode.Space);
        if (pulei == true)
        {
            fisica.AddForce(new Vector2(0, forcaPulo));
        }   
    }
}
