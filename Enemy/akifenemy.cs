using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class akifenemy : MonoBehaviour
{
    [SerializeField] Transform target;
    NavMeshAgent agent;

    public float speed;



   
    public float takipsure;
    void Start()
    {
        takipsure = 0f;
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
     

    }

    void Update()
    {


        if (Vector2.Distance(transform.position, target.position) > 20f && takipsure > 0)
        {
            agent.isStopped = false;
            agent.SetDestination(target.position);

            takipsure -= Time.deltaTime;
            // this.GetComponent<NavMeshAgent>().enabled = false;
        }
        else if (Vector2.Distance(transform.position, target.position) > 20f && takipsure <= 0)
        {

            agent.isStopped = true;
        }
        if ( Vector2.Distance(transform.position, target.position) < 20f)
        {

            agent.SetDestination(target.position);
            agent.isStopped = false;
            takipsure = 3f;
        }
        

      
    }
     
       





}
  

