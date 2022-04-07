using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TiroController : MonoBehaviour
{
    public float velocidade = 10;
    Rigidbody2D fisica;

    void Start()
    {
        fisica = GetComponent<Rigidbody2D>();
    }

    private void OnEnable()
    {
        Invoke("MeDestroi", 5);
    }
    private void OnDisable()
    {
        CancelInvoke();
    }

    void Update()
    {
        fisica.velocity = new Vector2(0, velocidade);
    }

    void MeDestroi()
    {
        //Não vamos mais destruir objetos! Vamos apenas desativa-lo
        //Destroy(gameObject);
        gameObject.SetActive(false);
    }
}
