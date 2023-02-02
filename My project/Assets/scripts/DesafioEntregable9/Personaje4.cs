using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Personaje4 : MonoBehaviour
{
    public Camera PC; //Player Camera
    public Rigidbody PR; // Player rigidbody
    public Animator PAT; //Player animator
    float movX = 0f;
    float movY = 0f;
    public float movSpeed = 1f;
    public float rotSpeed = 10f;
    public float JumpForce = 5f;
    [SerializeField] float shootRange = 100f;
  
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Movimiento();
        jump();  
        Shoot();
    }
    
    void FixedUpdate() 
    {
       // Movimiento();
    }

    
    void Movimiento()
    {
        movX = Input.GetAxis("Horizontal");
        movY = Input.GetAxis("Vertical");
        Vector3 PlayerInput = new Vector3(movX, 0, movY) * movSpeed * Time.deltaTime;
        //PR.AddForce(PlayerInput * movSpeed,ForceMode.VelocityChange);
        transform.Translate(PlayerInput,PC.transform);
        if(Input.GetKey(KeyCode.Q))
        {
            transform.Rotate(Vector3.down * Time.deltaTime * rotSpeed);
        }

        if(Input.GetKey(KeyCode.E))
        {
            transform.Rotate(Vector3.up * Time.deltaTime * rotSpeed);
        }
    }

    void Shoot()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            RaycastHit Impact;
            if(Physics.Raycast(PC.transform.position,PC.transform.forward,out Impact,shootRange))
            {
                Debug.Log(Impact.transform.name);
            }
            PAT.SetBool("BShoot",true);
        }
        else
        {
            PAT.SetBool("BShoot",false);
        }
    }

    void jump()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            RaycastHit rj;
            if(Physics.Raycast(transform.position,Vector3.down,out rj,2f))
            {
                PR.AddForce(new Vector3(0,1,0) * JumpForce ,ForceMode.Impulse);
            }
        
        }
    }

}
