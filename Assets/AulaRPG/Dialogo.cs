using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Events;

public class Dialogo : MonoBehaviour
{
    public GameObject canvasDaInstrucao;

    public GameObject canvasDialogo;
    bool estaDentroDaArea;

    public TextMeshProUGUI texto;
    public List<string> listaDeDialogo;
    int dialogoAtual;

    public UnityEvent terminouDialogo;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        canvasDaInstrucao.SetActive(true);
        estaDentroDaArea = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        canvasDaInstrucao.SetActive(false);
        estaDentroDaArea = false;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (estaDentroDaArea)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                DialogoInteragiu();
            }
        }
    }

    void DialogoInteragiu()
    {
        if(dialogoAtual >= listaDeDialogo.Count)
        {
            dialogoAtual = 0;
            canvasDialogo.SetActive(false);
            terminouDialogo.Invoke();
            return;
        }

        canvasDialogo.SetActive(true);
        texto.text = listaDeDialogo[dialogoAtual];
        dialogoAtual++;
    }
}
