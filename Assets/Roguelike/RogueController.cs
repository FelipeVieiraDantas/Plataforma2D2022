using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class RogueController : MonoBehaviour
{
    [Header("Coisas de Coletável")]
    public int quantidadeColetavel;
    public TMPro.TextMeshProUGUI textoDeColetavel;

    Animator anim;

    [Header("Coisas de HP")]
    public int hpAtual = 3;
    public Sprite[] spritesCoracao;
    public Image imagemNoCanvas;

    [Header("Movimento")]
    public float velocidade = 10;
    Rigidbody2D fisica;

    bool knockback;
    public float tempoDeKnockback = 0.5f;
    public float forcaKnockback = 100;

    [Header("Dash")]
    public bool comprouDash;
    public float tempoDeDash = 0.2f;
    public float forcaDash = 700;
    bool fazendoDash;

    void Start()
    {
        fisica = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

        quantidadeColetavel = PlayerPrefs.GetInt("Moedas");
        textoDeColetavel.text = quantidadeColetavel.ToString();
    }
    void Update()
    {
        if (knockback || fazendoDash)
        {
            return;
        }

        if (Input.GetKeyDown(KeyCode.X))
        {
            anim.SetTrigger("Ataque");
        }

        float movimentoH = Input.GetAxis("Horizontal");
        float movimentoV = Input.GetAxis("Vertical");
        fisica.velocity = new Vector2(movimentoH, movimentoV) * velocidade;

        //Dash
        if (comprouDash && Input.GetKeyDown(KeyCode.LeftShift))
        {
            fisica.velocity = Vector2.zero;
            //Se o jogador não está apertando nada, vai pra direita
            if(movimentoH == 0 && movimentoV == 0)
            {
                movimentoH = 1;
            }
            fisica.AddForce(new Vector2(movimentoH, movimentoV) * forcaDash);
            fazendoDash = true;
            Invoke("VoltaDash", tempoDeDash);
        }
    }

    void VoltaDash()
    {
        fazendoDash = false;
    }

    public void TomarDano(Transform inimigo)
    {
        hpAtual--; //hpAtual = hpAtual -1; 
        if (hpAtual > 0)
        {
            imagemNoCanvas.sprite = spritesCoracao[hpAtual - 1];
        }
        else
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }


        Vector3 direcao = inimigo.position - transform.position;
        direcao.Normalize();

        fisica.velocity = Vector2.zero;
        fisica.AddForce(direcao * forcaKnockback);
        knockback = true;
        Invoke("VoltaKnockback", tempoDeKnockback);
    }
    void VoltaKnockback()
    {
        knockback = false;
    }

    public void Atacar()
    {
        //A função Atacar está sendo chamada da Animação
        foreach(Collider2D inimigo in
            Physics2D.OverlapCircleAll(transform.position, 0.25f))
        {
            //Se quiser não pegar a visão do inimigo
            /*if (inimigo.isTrigger)
                continue;*/

            if (inimigo.GetComponent<RogueInimigo>())
            {
                //Se entrou no if, é um inimigo
                inimigo.GetComponent<RogueInimigo>().TomarDano(transform);
            }
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Moeda")
        {
            quantidadeColetavel++;
            textoDeColetavel.text = quantidadeColetavel.ToString();
            Destroy(collision.gameObject);

            Salvar();
        }
    }

    public void Salvar()
    {
        //Salvar:
        PlayerPrefs.SetInt("Moedas", quantidadeColetavel);
        PlayerPrefs.Save();
    }
}
