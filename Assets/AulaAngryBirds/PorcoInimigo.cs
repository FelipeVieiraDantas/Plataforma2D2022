using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PorcoInimigo : MonoBehaviour
{
    public int hp = 3;
    public List<Sprite> spritePorHp;
    SpriteRenderer spriteRenderer;
    public float impactoParaDano = 3;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Rigidbody2D fisicaDeQuemBateu = collision.collider.GetComponent<Rigidbody2D>();
        if(fisicaDeQuemBateu != null && 
            fisicaDeQuemBateu.velocity.magnitude > impactoParaDano)
        {
            hp--; //hp = hp -1;
            if(hp < 0)
            {
                Destroy(gameObject);
                return;
            }
            spriteRenderer.sprite = spritePorHp[hp];
        }
    }
}
