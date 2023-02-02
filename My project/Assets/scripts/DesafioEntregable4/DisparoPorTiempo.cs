using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisparoPorTiempo : MonoBehaviour
{
    public GameObject shooter; //variable que contiene un EmptyGameobject, contiene las cordenadas de instancia
    public GameObject Bullet;//contiene el prefab de la bala que se va a disparar
    Vector3 tankRotation; //variable para rotar el tanque
    [SerializeField]
    float RotationSpeed = 10f;
    [SerializeField]
    float cooldownTime = 1f;
    float nextFireTime = 0; // variable para hacer suma de cooldown al tiempo
    
    void Update()
    {
        TankRotate();
        TankShot();
    }

    void TankRotate() //movimiento del tanque
    {
        if(Input.GetKey(KeyCode.RightArrow))  // input para hacer que el tanque rote hacia la derecha
        {
            tankRotation = Vector3.up;
            transform.Rotate(tankRotation * RotationSpeed * Time.deltaTime);
        }

        if(Input.GetKey(KeyCode.LeftArrow)) // input para hacer que el tanque rote hacia la izquierda
        {
            tankRotation = Vector3.down; 
            transform.Rotate(tankRotation * RotationSpeed * Time.deltaTime); 
        }
    }

    void TankShot() // funcion para que el tanque dispare
    {
        {
        if(Time.time > nextFireTime) 
            {  
                    Instantiate(Bullet,shooter.transform.position,transform.rotation);
                    nextFireTime = Time.time + cooldownTime; // empiezo el cooldown
            }

        }
    }
}        

