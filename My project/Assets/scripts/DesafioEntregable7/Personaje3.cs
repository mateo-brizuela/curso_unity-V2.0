using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Personaje3 : MonoBehaviour
{

    Vector3 respawnPos;
    float movX = 0f;
    float movY = 0f;
    public float movSpeed = 5f;
    public float rotSpeed = 10f;
    float nextColissionTime = 0f;
    float cooldownTime = 2f;
    // Start is called before the first frame update
    void Start()
    {
        respawnPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Movimiento();
        Respawn(respawnPos);
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

    void Respawn(Vector3 respawnPos)
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            transform.position = respawnPos;
        }
    }

    void OnTriggerEnter(Collider Col) 
    {
        Vector3 oScale = new Vector3 (1,1,1);
        if(Col.transform.gameObject.tag == "portal" && Time.time > nextColissionTime)
        {
            if(transform.localScale == oScale)
            {
                transform.localScale *= 0.5f;
            }
            else
            {
                transform.localScale *= 2;
            }

            nextColissionTime = Time.time + cooldownTime;
        }

    }
}
