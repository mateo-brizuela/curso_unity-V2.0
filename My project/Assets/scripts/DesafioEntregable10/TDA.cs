using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TDA : MonoBehaviour
{
    int [] opciones = new int[10];
    // Start is called before the first frame update
    void Start()
    {

    }


    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Alpha1)) // tecla para cargar numeros random
        {
            Debug.Log("cargando numeros aleatorios");
            for(int f = 0 ; f < 10 ; f++)
            {
                int Rn = Random.Range(0,99);
                opciones[f] = Rn;
                Debug.Log("numero random cargado");
            }
        }

        if(Input.GetKeyDown(KeyCode.Alpha2))
        {
            Debug.Log("recorriendo la lista de atras hacia adelante");
            for(int f = 0 ; f < 10 ; f++)
            {
                Debug.Log(opciones[f]);
            }
        }

        if(Input.GetKeyDown(KeyCode.Alpha3))
        {
            Debug.Log("recorriendo la lista de adelante hacia atras");
            for(int f = 9 ; f >= 0 ; f--)
            {
                Debug.Log(opciones[f]);
            }
        }

        if(Input.GetKeyDown(KeyCode.Alpha4))
        {
            Debug.Log("--------------------------------");
        }
    }
}
