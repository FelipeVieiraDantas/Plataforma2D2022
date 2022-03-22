using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HollowControle : MonoBehaviour
{
    Rigidbody2D fisica;
    public float velocidade = 10;
    public float forcaPulo = 100;

    SpriteRenderer desenhista;
    Animator animacao;

    public Transform posicaoDoPe;
    public float raio = 0.2f;
    public LayerMask oQueEhChao;
    bool estamosNoChao;

    // Start is called before the first frame update
    void Start()
    {
        fisica = GetComponent<Rigidbody2D>();
        desenhista = GetComponent<SpriteRenderer>();
        animacao = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //Verificar se está no chão
        if(Physics2D.OverlapCircle(posicaoDoPe.position,
            raio,oQueEhChao) == null)
        {
            estamosNoChao = false;
        }
        else
        {
            estamosNoChao = true;
        }



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
        if (pulei == true && estamosNoChao == true)
        {
            fisica.AddForce(new Vector2(0, forcaPulo));
        }   

        //Flipar o personagem caso necessário
        if(taApertando < 0)
        {
            desenhista.flipX = true;
        }
        else if(taApertando > 0)
        {
            desenhista.flipX = false;
        }

        //Animação
        if(taApertando == 0)
        {
            animacao.SetBool("Andando", false);
        }
        else
        {
            animacao.SetBool("Andando", true);
        }
    }
}
