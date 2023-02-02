using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class proyectile : MonoBehaviour
{
    public float Speed = 2f; // velocidad de la bala
    public Vector3 direction; // direccion de la bala
    public float destroyTime = 5; // tiempo para que la bala se destruya

    void Update()
    {
        direction = Vector3.back;
        ProyectileMovement(); // ejecuto la funcion en update
        ProyectileDestroy(); // ejecuto la funcion en update
    }

    void ProyectileMovement() // funcion para que el proyectil se mueva hacia adelante
    {
        transform.Translate(direction * Speed * Time.deltaTime);
    }

    void ProyectileDestroy() // funcion que destruye el proyectil
    {
        Destroy(gameObject, destroyTime);
    }
}
