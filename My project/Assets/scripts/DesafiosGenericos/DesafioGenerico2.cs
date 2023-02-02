using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DesafioGenerico2 : MonoBehaviour
{
    bool binary = true;
    int numero = 0;
    float flotante = 0;
    Vector3 v3 = (new Vector3(0f,0f,0f));
    string texto = "Hola";
    char ch = 'H' ;

    
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(binary);
        Debug.Log(numero);
        Debug.Log(flotante);
        Debug.Log(v3);
        Debug.Log(texto);
        Debug.Log(ch);
        binary = false;
        numero ++;
        flotante =- 0.5f;
        v3 = new Vector3(1f,1f,1f);
        texto = "HolaMundo";
        ch = 'g';
        Debug.Log("nuevo " + binary);
        Debug.Log("nuevo " +numero);
        Debug.Log("nuevo " +flotante);
        Debug.Log("nuevo " +v3);
        Debug.Log("nuevo " +texto);
        Debug.Log("nuevo " +ch);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
