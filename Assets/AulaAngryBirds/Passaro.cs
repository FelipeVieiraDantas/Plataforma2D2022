using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Passaro : MonoBehaviour
{
    Rigidbody2D fisica;
    SpringJoint2D elastico;

    bool estouClicando;

    Vector2 velocidadeAnterior;

    // Start is called before the first frame update
    void Start()
    {
        fisica = GetComponent<Rigidbody2D>();
        elastico = GetComponent<SpringJoint2D>();
    }

    private void OnMouseDown()
    {
        estouClicando = true;
    }

    private void OnMouseUp()
    {
        estouClicando = false;
        fisica.isKinematic = false;
        elastico.enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (estouClicando)
        {
            Vector3 mouseNoMundo = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mouseNoMundo.z = 0;

            transform.position = mouseNoMundo;
        }

        //O pássaro foi arremessado
        if (elastico.enabled)
        {
            if(velocidadeAnterior.magnitude > fisica.velocity.magnitude)
            {
                elastico.enabled = false;
                fisica.velocity = velocidadeAnterior;
            }

            velocidadeAnterior = fisica.velocity;
        }
    }
}
