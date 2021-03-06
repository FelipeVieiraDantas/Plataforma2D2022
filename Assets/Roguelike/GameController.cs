using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public List<GameObject> prefabSala;
    public int quantidadeDeSalas;
    public float distanciaSalas = 11.27f;

    public GameObject[] prefabInimigo;

    public GameObject prefabMoeda;
    public int minimoMoedaPorSala = 0;
    public int maximoMoedaPorSala = 5;

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
            int aleatorio = Random.Range(0, prefabSala.Count);
            GameObject novaSala = Instantiate(prefabSala[aleatorio]);
            novaSala.transform.position = new Vector3(0, proximoY, 0);
            proximoY += distanciaSalas;

            //Se for loja, nunca mais pode aparecer loja
            if(aleatorio == 2)
            {
                prefabSala.RemoveAt(2);
            }

            //Se achou um filho chamado "PosicaoInimigos" ...
            if (novaSala.transform.Find("PosicaoInimigos"))
            {
                Porta porta =
                    novaSala.GetComponentInChildren<Porta>();
                porta.listaDeInimigos = new List<GameObject>();

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
                    GameObject novoInimigo = Instantiate(prefabInimigo[inimigoAleatorio], 
                        filho.position, filho.rotation);
                    //chanceDeNaoTer += 0.2f;

                    //Colocar esse inimigo na porta
                    porta.listaDeInimigos.Add(novoInimigo);
                    novoInimigo.GetComponent<RogueInimigo>()
                        .porta = porta;
                }
            }

            //Gerar Colet?veis
            int moedasNessaSala = Random.Range(minimoMoedaPorSala, 
                maximoMoedaPorSala);
            for(int moedaAtual = 0; moedaAtual < moedasNessaSala; moedaAtual++)
            {
                Transform posMin = novaSala.transform.Find("Posi??oM?nima");
                Transform posMax = novaSala.transform.Find("Posi??oM?xima");
                Vector3 posMoeda = new Vector3(
                    Random.Range(posMin.position.x, posMax.position.x),
                    Random.Range(posMin.position.y, posMax.position.y),
                    0);
                Instantiate(prefabMoeda, posMoeda, Quaternion.identity);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
