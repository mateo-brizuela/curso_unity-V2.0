using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Personaje : MonoBehaviour
{
    float movX = 0f;
    float movY = 0f;
    public float movSpeed = 1f;
    public Animation correr;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Movimiento();
    }

    void Movimiento()
    {
        movX = Input.GetAxis("Horizontal");
        movY = Input.GetAxis("Vertical");
        transform.Translate(new Vector3(movX, 0, movY) * movSpeed * Time.deltaTime);
    }
}
