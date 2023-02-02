using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zombie2 : zombie
{
    void Start() 
    {
        life = 200;    
    }

    public override void attackPlayer()
    {
        float playerDistance = Vector3.Distance(playerTransform.position, transform.position);
        if(playerDistance < 2f && Time.time > endCooldown)
        {
            attack = true;
            move = false;
            ZAC.SetBool("moving", false);
            ZAC.SetTrigger("attacking");
            endCooldown = cooldownTime + Time.time;
        }else if(playerDistance > 3.5f || Time.time > endCooldown)
        {
            move = true;
            attack = false;
        }
    }
}
