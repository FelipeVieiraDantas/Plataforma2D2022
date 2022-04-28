using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimentoSimples : MonoBehaviour
{
    public float velocidade = 10;

    // Update is called once per frame
    void Update()
    {
        float movimento = Input.GetAxis("Horizontal");
        transform.Translate(movimento * velocidade * Time.deltaTime, 0, 0);
    }
}
