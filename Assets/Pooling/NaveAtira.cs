using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NaveAtira : MonoBehaviour
{
    public Pooling poolingDoTiro;

    public float cadenciaDeTiro = 0.2f;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            Atira();
        }
        if (Input.GetKeyUp(KeyCode.G))
        {
            CancelInvoke();
        }
    }

    void Atira()
    {
        //Não quero mains instanciar, quero pegar da lista do pooling
        //Instantiate(tiroPrefab, transform.position, transform.rotation);

        GameObject tiroDisponivel = poolingDoTiro.EncontraObjetoPraMim();
        if (tiroDisponivel != null)
        {
            tiroDisponivel.transform.position = transform.position;
            tiroDisponivel.SetActive(true);
        }

        Invoke("Atira", cadenciaDeTiro);
    }
}
