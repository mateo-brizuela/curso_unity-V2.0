using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cañon : MonoBehaviour
{
    public GameObject shooter; //variable que contiene un EmptyGameobject, contiene las cordenadas de instancia
    public GameObject Bullet;// es la variable que contiene el prefab de la bala que se va a disparar
    Vector3 tankRotation; // es la variable para rotar el tanque
    [SerializeField]
    float RotationSpeed = 10f; // la velocidad con la que se rota el tanque
    public float cooldownTime = 1f; //cooldown entre disparos del tanque
    float nextFireTime = 0; // variable para hacer suma de cooldown al tiempo
    int burst = 0; // variable para disparar en modo rafaga


    void Update()
    {
        TankRotate();
        TankShot(); // en ambas lineas ejecuto las funciones
    }

    void TankRotate() // funcion que contiene  el movimiento del tanque
    {
        if(Input.GetKey(KeyCode.RightArrow))  // input para hacer que el tanque rote hacia la derecha
        {
            tankRotation = Vector3.up;
            transform.Rotate(tankRotation * RotationSpeed * Time.deltaTime);
        }

        if(Input.GetKey(KeyCode.LeftArrow)) // input para hacer que el tanque rote hacia la isquierda
        {
            tankRotation = Vector3.down; 
            transform.Rotate(tankRotation * RotationSpeed * Time.deltaTime); 
        }
    }

    void TankShot() // funcion para que el tanque dispare
    {
        if(Time.time > nextFireTime) //  pregunta si el cooldown ya paso
        {
            if(Input.GetKeyDown(KeyCode.Space)) // si aprieto espacio se dispara una bala 
            {
                Instantiate(Bullet,shooter.transform.position,transform.rotation);
                nextFireTime = Time.time + cooldownTime;// activo el cooldown
            }
        }

        if(Input.GetKeyDown(KeyCode.J))// rafaga de 2 disparos
        {
            burst = 2;
        }

        if(Input.GetKeyDown(KeyCode.K)) // rafaga de 3 disparos
        {
            burst = 3;                                 
        }

        if(Input.GetKeyDown(KeyCode.L)) // rafaga de 4 disparos
        {
            burst = 4;
        }
       
        if(Time.time > nextFireTime) // disparo de rafagas
            {  
                if(burst > 0)
                {
                    Instantiate(Bullet,shooter.transform.position,transform.rotation);
                    burst--;
                    nextFireTime = Time.time + cooldownTime;
                }
            }

    }
}
