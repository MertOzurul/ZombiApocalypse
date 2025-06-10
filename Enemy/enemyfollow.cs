using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class Enemyfollow : MonoBehaviour
{
    [SerializeField] Transform target;
   public  NavMeshAgent nav;

    public float speed;



    public float takipsure;
    void Start()
    {
        takipsure = 0f;
        nav = GetComponent<NavMeshAgent>();
        nav.updateRotation = false;
        nav.updateUpAxis = false;
    
    }

    void Update()
    {
        if(Vector2.Distance(transform.position, target.position) < 25f && Vector2.Distance(transform.position, target.position) > 5f)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
            nav.SetDestination(target.position);
            
        }
        else if(Vector2.Distance(transform.position, target.position) < 5f) { nav.isStopped = true; }

    








    }



}
