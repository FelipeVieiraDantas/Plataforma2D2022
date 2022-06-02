using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RogueInimigo : MonoBehaviour
{
    [Header("Sobre HP:")]
    public Image barraDeHp;
    public int hpAtual;
    public int hpMaximo = 5;
    bool knockback;
    public float forcaKnockback = -600;
    public float tempoDeKnockback = 0.2f;

    public float velocidade = 5;
    Rigidbody2D fisica;
    Transform player;

    // Start is called before the first frame update
    void Start()
    {
        hpAtual = hpMaximo;
        fisica = GetComponent<Rigidbody2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<RogueController>())
        {
            player = collision.transform;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(player == null || knockback)
        {
            return;
        }

        Vector3 direcao = player.position - transform.position;
        direcao.Normalize();
        fisica.velocity = direcao * velocidade;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.GetComponent<RogueController>())
        {
            collision.collider.GetComponent<RogueController>()
                .TomarDano(transform);
        }
    }

    public void TomarDano(Transform inimigo)
    {
        hpAtual--; //hpAtual = hpAtual -1; 

        barraDeHp.fillAmount = Mathf.InverseLerp(0, hpMaximo, hpAtual);

        if(hpAtual <= 0)
        {
            Destroy(gameObject);
        }


        Vector3 direcao = inimigo.position - transform.position;
        direcao.Normalize();

        fisica.velocity = Vector2.zero;
        fisica.AddForce(direcao * forcaKnockback);
        knockback = true;
        Invoke("VoltaKnockback", tempoDeKnockback);

        //Ligar o quadrado branco
        transform.GetChild(0).gameObject.SetActive(true);
    }
    void VoltaKnockback()
    {
        knockback = false;
        transform.GetChild(0).gameObject.SetActive(false);
    }
}
