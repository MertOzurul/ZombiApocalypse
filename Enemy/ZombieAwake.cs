using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ZombieAwake : MonoBehaviour
{
    public Transform selfpoint;
    public float selfrange = 0.5f;
    public LayerMask playerLayer;
    float sleeptime = 3;
    bool detected;
    bool isover ;
    public NavMeshAgent enm;
   
    void Start()
    {
        enm = GetComponent<Enemyfollow>().nav;
    }

    // Update is called once per frame
    void Update()
    {

        
        Detect();
      

        
      
    }

    void Detect()

    {
        
        Collider2D[] findplayers = Physics2D.OverlapCircleAll(selfpoint.position, selfrange, playerLayer);

        if (findplayers.Length > 0)
        {detected = true;
            
            
            if (sleeptime > 0  && detected ) { sleeptime -= Time.deltaTime; } 
            
            
            else if (sleeptime <= 0) 
            { 
                isover = true; GetComponent<Enemyfollow>().enabled = true; 
            }
           
        }
        else { detected = false;   if (!detected && sleeptime<=3  && !isover) { sleeptime += Time.deltaTime; } }
            
        

    }

    
    void OnDrawGizmosSelected()
    {
        if (selfpoint == null)
        {
            return;
        }

        Gizmos.DrawWireSphere(selfpoint.position, selfrange);
    }
}
