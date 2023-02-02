using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Personaje5 : MonoBehaviour
{
    public zombie zPunt;
    public HudScripts punt; 
    public Rigidbody PR; // Player rigidbody
    public Animator PAT; //Player animator
    public Camera PC; //Player camera
    #region  movement variables
    float movX = 0f; // variable for player movement
    float movY = 0f; // variable for player movement
    [SerializeField] float movSpeed = 5f;
    float cMovSpeed; // copy of movSpeed
    [SerializeField] float runSpeed = 10f;
    [SerializeField] float JumpForce = 5f;
    #endregion
    #region ammo and shoot variables
    public int mAmmo = 0; //magazine ammo
    public int tAmmo = 0; //Total ammo
    int nAmmo = 0; // Need ammo
    public bool cShoot = false; // Can you shoot?
    [SerializeField] float shootRange = 100f;
    public GameObject bloodEffect;
    public GameObject meatEffect;
    #endregion
    #region life and lifeTaken variables
    public float life = 100;
    [SerializeField] float takenLife = 25;
    public bool attacked = false;
    #endregion

  
    // Start is called before the first frame update
    void Start()
    {
        cMovSpeed = movSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        Movimiento();
        Shoot();
        reload();
        jump();  
        TakeDamage();
        if(Input.GetKeyDown(KeyCode.F)) //this is for test the life in the hud
        {
            life --;  
            punt.cLife = true;
        }
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

        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D))
        {
            PAT.SetBool("moving" , true);
            if(Input.GetKey(KeyCode.LeftShift))
            {
                movSpeed =+ runSpeed;
                PAT.SetBool("running", true);
                cShoot = false; // disable shooting when player runs || enabled shoot in another script
            }else
            {
                movSpeed = cMovSpeed; // back the player to his original speed
                PAT.SetBool("running" , false);
            }
        }else
        {
            PAT.SetBool("moving", false);
        }

        if(PlayerInput == Vector3.zero)  // if the player is still execute the idle animation
        {
            PAT.SetBool("moving" ,false);
            PAT.SetBool("running" ,false);
        }

    }

    void Shoot()
    {
        if(Input.GetKeyDown(KeyCode.Mouse0) && mAmmo > 0 && cShoot == true)
        {
            RaycastHit shootHit;
            if (Physics.Raycast(PC.transform.position, PC.transform.forward,out shootHit,shootRange))// raycast
            {
                if(shootHit.transform.CompareTag("zombie"))
                {
                    GameObject zShooted = GameObject.Find(shootHit.transform.name);
                    zPunt = zShooted.GetComponent<zombie>();
                    GameObject cBloodEffect = Instantiate(bloodEffect,shootHit.point,Quaternion.LookRotation(shootHit.normal));
                    GameObject cMeatEffect = Instantiate(meatEffect,shootHit.point,Quaternion.LookRotation(shootHit.normal));
                    Destroy(cBloodEffect,1f); 
                    Destroy(cMeatEffect,0.4f);
                    zPunt.zAttacked = true; // zombie was attacked
                }
            }
            PAT.SetTrigger("shooting"); 
            mAmmo --;
            punt.cAmmo = true;
        }
                
        if (Input.GetKey(KeyCode.Mouse1))
        {
            PAT.SetBool("aiming", true);
        }else
        {
            PAT.SetBool("aiming", false);
        }
    }

    void reload()
    {
        if(Input.GetKeyDown(KeyCode.R))
        {     
            nAmmo = 30 - mAmmo;
            if(nAmmo < tAmmo)
            {
                tAmmo -= nAmmo;
                mAmmo += nAmmo;
                PAT.SetBool("reloading", true);
            } else if(tAmmo > 0)
            {
                mAmmo += tAmmo;
                tAmmo = 0;
                PAT.SetBool("reloading", true);
            }

            punt.cAmmo = true;

        }else
        {
            PAT.SetBool("reloading", false);
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

    void TakeDamage()
    {
        if(attacked == true)
        {
            life -= takenLife;
            punt.cLife = true;
            attacked = false;
        }
    }

}
