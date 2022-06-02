using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public GameObject[] prefabSala;
    public int quantidadeDeSalas;
    public float distanciaSalas = 11.27f;

    public GameObject[] prefabInimigo;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(GerarSalas());
    }

    IEnumerator GerarSalas()
    {
        float proximoY = distanciaSalas;
        for (int i = 0; i < quantidadeDeSalas; i++)
        {
            yield return new WaitForEndOfFrame();
            int aleatorio = Random.Range(0, prefabSala.Length);
            GameObject novaSala = Instantiate(prefabSala[aleatorio]);
            novaSala.transform.position = new Vector3(0, proximoY, 0);
            proximoY += distanciaSalas;

            //Se achou um filho chamado "PosicaoInimigos" ...
            if (novaSala.transform.Find("PosicaoInimigos"))
            {
                //float chanceDeNaoTer = 0;
                foreach(Transform filho in
                    novaSala.transform.Find("PosicaoInimigos"))
                {
                    yield return new WaitForEndOfFrame();

                    /*if(Random.value < chanceDeNaoTer)
                    {
                        continue;
                    }*/

                    int inimigoAleatorio = Random.Range(0, prefabInimigo.Length);
                    Instantiate(prefabInimigo[inimigoAleatorio], 
                        filho.position, filho.rotation);
                    //chanceDeNaoTer += 0.2f;
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
