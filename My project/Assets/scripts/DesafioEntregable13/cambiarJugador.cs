using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cambiarJugador : MonoBehaviour
{
    public GameObject particulasCubo;
    void Start() 
    {
        Eventos.Teventos += TP;
        Eventos.Teventos += onFire;
        Eventos.Teventos += estoymojado;
    }

    void TP(int num1)
    {
        if(num1 == 1)
        {
            Debug.Log(transform.name + " me teletransporte");    
        }
    }

    void onFire(int num2) 
    {
        if(num2 == 2)
        {
            if(particulasCubo.activeInHierarchy == false)
            {
                particulasCubo.SetActive(true);
                Debug.Log(transform.name + "voy prendido fuego");
            }else
            {
                particulasCubo.SetActive(false);
            }
            
        }
    }

    void estoymojado(int num3)
    {
        if(num3 == 3)
        Debug.Log("estoy mojado");
    }
}
