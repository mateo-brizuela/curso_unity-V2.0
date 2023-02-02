using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Personaje2 : MonoBehaviour
{
    float movX = 0f;
    float movY = 0f;
    public float movSpeed = 1f;
    public float rotSpeed = 1f;
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
        if(Input.GetKey(KeyCode.Q))
        {
            transform.Rotate(Vector3.down * Time.deltaTime * rotSpeed);
        }

        if(Input.GetKey(KeyCode.E))
        {
            transform.Rotate(Vector3.up * Time.deltaTime * rotSpeed);
        }
    }
}
