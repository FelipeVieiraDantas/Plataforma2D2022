using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public GameObject prefabSala;
    public int quantidadeDeSalas;
    public float distanciaSalas = 11.27f;

    // Start is called before the first frame update
    void Start()
    {
        float proximoY = distanciaSalas;
        for (int i = 0; i < quantidadeDeSalas; i++)
        {
            GameObject novaSala = Instantiate(prefabSala);
            novaSala.transform.position = new Vector3(0, proximoY, 0);
            proximoY += distanciaSalas;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
