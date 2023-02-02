using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Enemigo : MonoBehaviour
{
    public Transform player;
    enum EnemyType {type1,type2};
    [SerializeField]
    private EnemyType enemy;
    [SerializeField]
    float maxdist = 2;
    [SerializeField]
    float speed = 2;
    // Update is called once per frame
    void Update()
    {
        playerfollow(enemy , player , maxdist, speed);
    }

    float playerDistance(Transform player)
    {
        float dist = Vector3.Distance(transform.position , player.position);
        Debug.Log(dist);
        return(dist);
    }

    void playerfollow(EnemyType enemy, Transform player , float maxdist , float speed)
    {
        switch(enemy)
        {
            case EnemyType.type1:
                Quaternion rotation = Quaternion.LookRotation(player.position - transform.position);
                transform.rotation = Quaternion.Lerp(transform.rotation , rotation , Time.deltaTime * speed);
            break;

            case EnemyType.type2:
                float dist = playerDistance(player);
                if(dist > maxdist) 
                {
                    transform.position = Vector3.MoveTowards(transform.position, player.position, Time.deltaTime * speed);
                }else
                {
                    rotation = Quaternion.LookRotation(player.position - transform.position);
                    transform.rotation = rotation;
                }
            break;


        }
    }
}
