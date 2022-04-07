using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pooling : MonoBehaviour
{
    public GameObject objetoPrefab;
    public int quantidadeInicial = 20;

    public List<GameObject> listaDeObjetos;

    public bool vaiAdicionar = true;

    // Start is called before the first frame update
    void Start()
    {
        listaDeObjetos = new List<GameObject>();

        //Garantir que tudo que eu escrever dentro do for
        //Será repetido '20' vezes
        for (int i = 0; i < quantidadeInicial; i++)
        {
            GameObject novoTiro = Instantiate(objetoPrefab);
            listaDeObjetos.Add(novoTiro);
            novoTiro.SetActive(false);
        }
    }

    public GameObject EncontraObjetoPraMim()
    {
        for(int i = 0; i < listaDeObjetos.Count; i++)
        {
            //Checar se o item NÃO está ativo na hierarquia
            if (!listaDeObjetos[i].activeInHierarchy)
            {
                return listaDeObjetos[i];
            }
        }
        //Não tem nenhum tiro fora de uso

        if (vaiAdicionar)
        {
            GameObject novoTiro = Instantiate(objetoPrefab);
            listaDeObjetos.Add(novoTiro);
            return novoTiro;
        }

        return null;
    }
}
