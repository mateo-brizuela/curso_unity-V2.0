using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zombie : MonoBehaviour
{
    public LayerMask playerMesh;
    public Transform playerTransform;
    public Personaje5 punt;
    public float cooldownTime = 0.3f;
    public float endCooldown = 0;
    #region zombie variables
    public Animator ZAC; // zombie animator controller
    [SerializeField] bool detected;
    public bool attack;
    public bool move;
    [SerializeField] bool look;
    public bool zAttacked = false; // zombie was attacked??
    [SerializeField] float zombieSpeed = 1f;
    [SerializeField] float visionDistance = 5f;
    public int life = 100; 
    [SerializeField] int Tlife = 25; // taked life
    #endregion
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    
    void Update()
    {
        sensePlayer();
        attackPlayer();
        movement();
        ZTakeDamage();
    }

    void sensePlayer()
    {
        detected = Physics.CheckSphere(transform.position,visionDistance,playerMesh);
        if(detected == true)
        {
            look = true;
            ZAC.SetBool("moving", true);
        }else
        {
            move = false;
            look = false;
            ZAC.SetBool("moving", false);
        }
    }

    void movement()
    {
       if(look == true)
       {
            Vector3 playerDirection = new Vector3(playerTransform.position.x,transform.position.y,playerTransform.position.z);
            transform.LookAt(playerDirection);
            if(attack == false && move == true)
            {
                transform.position = Vector3.MoveTowards(transform.position,playerDirection,zombieSpeed * Time.deltaTime);
                ZAC.SetBool("moving", true);
            }
            if(move == false)
            {
                ZAC.SetBool("moving", false);
            }
       }

    }

    public virtual void attackPlayer()
    {
        float playerDistance = Vector3.Distance(playerTransform.position, transform.position);
        if(playerDistance < 2f && Time.time > endCooldown)
        {
            attack = true;
            move = false;
            ZAC.SetBool("moving", false);
            punt.attacked = true;
            ZAC.SetTrigger("attacking");
            endCooldown = cooldownTime + Time.time;
        }else if(playerDistance > 3.5f || Time.time > endCooldown)
        {
            move = true;
            attack = false;
        }
    }

    void ZTakeDamage()
    {
        if(zAttacked == true)
        {
            life = life - Tlife;
            if(life <= 0)
            {
                ZAC.SetBool("death", true);
                Destroy(gameObject,3f);
                enabled = false; // stop de update funtion because the zombie is dead
            }
            zAttacked = false;  
        }
    }

    /*
    void OnDrawGizmos() 
    {
        Gizmos.DrawWireSphere(transform.position,visionDistance);    
    }
    */
}
