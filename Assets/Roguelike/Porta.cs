using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Porta : MonoBehaviour
{
    public GameObject portaFechada;
    public GameObject portaAberta;
    public List<GameObject> listaDeInimigos;

    public void InimigoMorreu(GameObject quem)
    {
        listaDeInimigos.Remove(quem);
        if(listaDeInimigos.Count == 0)
        {
            portaFechada.SetActive(false);
            portaAberta.SetActive(true);
        }
    }
}
