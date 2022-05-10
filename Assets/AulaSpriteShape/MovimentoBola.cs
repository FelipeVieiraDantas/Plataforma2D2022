using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimentoBola : MonoBehaviour
{
    Rigidbody2D fisica;
    public float velocidade = 5;

    // Start is called before the first frame update
    void Start()
    {
        fisica = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        fisica.AddForce(new Vector2(Input.GetAxis("Horizontal") * velocidade, 0));
        if (Input.GetKeyDown(KeyCode.Space))
        {
            fisica.AddForce(new Vector2(0,300));
        }
    }
}
