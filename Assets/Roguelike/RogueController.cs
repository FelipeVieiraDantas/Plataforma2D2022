using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RogueController : MonoBehaviour
{
    public float velocidade = 10;
    Rigidbody2D fisica;

    bool knockback;
    public float tempoDeKnockback = 0.5f;
    public float forcaKnockback = 100;

    void Start()
    {
        fisica = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        if (knockback)
        {
            return;
        }

        float movimentoH = Input.GetAxis("Horizontal");
        float movimentoV = Input.GetAxis("Vertical");
        fisica.velocity = new Vector2(movimentoH, movimentoV) * velocidade;
    }

    public void TomarDano(Transform inimigo)
    {
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
}
