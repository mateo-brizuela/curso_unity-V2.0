using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class Eventos : MonoBehaviour
{
    public static event Action<int> Teventos; // eventos de c#
    
    void Update() 
    {
        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            Teventos?.Invoke(1);
        }

        if(Input.GetKeyDown(KeyCode.Alpha2))
        {
            Teventos?.Invoke(2);
        }    

        if(Input.GetKeyDown(KeyCode.Alpha3))
        {
            Teventos?.Invoke(3);
        }    
    }
}
