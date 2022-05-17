using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Passaro : MonoBehaviour
{
    Rigidbody2D fisica;
    SpringJoint2D elastico;

    bool estouClicando;

    Vector2 velocidadeAnterior;

    //Limites do pássaro
    public Transform estilingue;
    public float maxEstica = 3;

    bool esperando;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(!estouClicando)
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

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

    void ReiniciaFase()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    // Update is called once per frame
    void Update()
    {
        if(fisica.isKinematic == false && elastico.enabled == false)
        {
            if (fisica.velocity.magnitude < 0.1f)
            {
                if (!esperando)
                {
                    esperando = true;
                    Invoke("ReiniciaFase", 2);
                }
            }
        }

        if (estouClicando)
        {
            Vector3 mouseNoMundo = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mouseNoMundo.z = 0;

            Vector2 direcaoMouseEstilingue = mouseNoMundo - estilingue.position;

            if (direcaoMouseEstilingue.magnitude >= maxEstica)
            {
                Ray2D raioParaOMouse = new Ray2D(estilingue.position, direcaoMouseEstilingue);
                mouseNoMundo = raioParaOMouse.GetPoint(maxEstica);
            }

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
