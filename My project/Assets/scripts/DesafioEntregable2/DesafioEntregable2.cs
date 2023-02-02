using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DesafioEntregable2 : MonoBehaviour
{
    float vida = 100f;
    float velocidad = 1;
    Vector3 direccion = new Vector3(0,0,0);
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Movimiento(direccion,velocidad);
        Playerheal(ref vida);
        PlayerDamage(ref vida);
    }

    void Movimiento(Vector3 direccion, float velocidad) //movimiento del jugador usando "WASD"
    {
        if(Input.GetKey(KeyCode.W))
        {
            direccion = Vector3.forward;
            transform.Translate(direccion * velocidad * Time.deltaTime);
            Debug.Log("direccion: " + direccion);
        }
        
        if(Input.GetKey(KeyCode.S))
        {
            direccion = Vector3.back;
            transform.Translate(direccion * velocidad * Time.deltaTime);
            Debug.Log("direccion: " + direccion);
        }

        if(Input.GetKey(KeyCode.D))
        {
            direccion = Vector3.right;
            transform.Translate(direccion * velocidad * Time.deltaTime);
            Debug.Log("direccion: " + direccion);
        }

        if(Input.GetKey(KeyCode.A))
        {
            direccion = Vector3.left;
            transform.Translate(direccion * velocidad * Time.deltaTime);
            Debug.Log("direccion: " + direccion);
        }
    }

    void Playerheal(ref float vida) //curar jugador con "1"
    {
        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            vida ++;
            Debug.Log("vida: " + vida);
        }
    }

    void PlayerDamage(ref float vida) // dañar jugador con "2"
    {
        if(Input.GetKeyDown(KeyCode.Alpha2))
        {
            vida --;
            Debug.Log("vida: " + vida);
        }
    }
}
