using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RogueInimigo : MonoBehaviour
{
    public float velocidade = 5;
    Rigidbody2D fisica;
    Transform player;

    // Start is called before the first frame update
    void Start()
    {
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
        if(player == null)
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
}
