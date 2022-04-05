using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NaveControle : MonoBehaviour
{
    public float velocidade = 5;

    // Update is called once per frame
    void Update()
    {
        float movimentoX = Input.GetAxis("Horizontal");
        float movimentoY = Input.GetAxis("Vertical");

        Vector3 novoMovimento = new Vector3(movimentoX,movimentoY,0);
        //Translate adiciona um vetor � posi��o.
        transform.Translate(novoMovimento * Time.deltaTime * velocidade);

        //WorldToViewportPoint eu passo uma posi��o no mundo da Unity
        //Por exemplo, onde a nave est� (transform.position)
        //E ele retorna um vetor em porcentagem da tela.
        //0 se est� � esquerda. 1 se est� � direita
        //0 se est� em baixo. 1 se est� em cima
        Vector3 porcentagem = Camera.main.WorldToViewportPoint(transform.position);
        Debug.Log(porcentagem);

        porcentagem.x = Mathf.Clamp(porcentagem.x, 0, 1);
        /*
         * if(porcentagem.x <0){
         * porcentagem.x = 0;
         * }
         * if(porcentagem.x >1){
         * porcentagem.x = 1;
         * }
         */
        porcentagem.y = Mathf.Clamp(porcentagem.y, 0, 1);

        transform.position = Camera.main.ViewportToWorldPoint(porcentagem);
    }
}
