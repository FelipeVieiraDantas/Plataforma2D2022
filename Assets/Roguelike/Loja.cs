using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Loja : MonoBehaviour
{
    RogueController player;

    public Transform content;
    public Color corJaTem = Color.green;

    // Start is called before the first frame update
    void Start()
    {
        //Procura em TODOS os objetos da hierarquia quem � o player
        player = FindObjectOfType<RogueController>();
    }
    //Essa fun��o ser� chamada pelo bot�o
    public void Clicou(int emQuem)
    {
        //Venda
        if(player.comprouDash == true)
        {
            player.comprouDash = false;
            player.quantidadeColetavel += 5;
            player.textoDeColetavel.text =
                player.quantidadeColetavel.ToString();

            //Trocar cor do bot�o
            content.GetChild(0).
                GetComponent<Image>().color = Color.white;

            player.Salvar();
            return;
        }
        //Compra
        if (player.quantidadeColetavel >= 10)
        {
            player.comprouDash = true;
            player.quantidadeColetavel -= 10;
            player.textoDeColetavel.text =
                player.quantidadeColetavel.ToString();

            //Trocar cor do bot�o
            content.GetChild(0).
                GetComponent<Image>().color = corJaTem;

            player.Salvar();
        }
    }
}
