using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NaveAtira : MonoBehaviour
{
    public GameObject tiroPrefab;
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
        Instantiate(tiroPrefab, transform.position, transform.rotation);
        Invoke("Atira", cadenciaDeTiro);
    }
}
