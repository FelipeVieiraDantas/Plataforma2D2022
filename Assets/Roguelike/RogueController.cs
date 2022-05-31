using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class RogueController : MonoBehaviour
{
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

    void Start()
    {
        fisica = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }
    void Update()
    {
        if (knockback)
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
        //Na aula que vem, fazemos o ataque funcionar
    }

}
