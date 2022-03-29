using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControleMouse : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Só se o jogador clicou com o botão esquerdo
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 posicaoMouse = Input.mousePosition;
            posicaoMouse = Camera.main.ScreenToWorldPoint(posicaoMouse);
            transform.position = posicaoMouse;
        }
    }
}
