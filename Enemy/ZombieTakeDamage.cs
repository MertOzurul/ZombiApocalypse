using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ZombieTakeDamage : MonoBehaviour
{
  public  float zombiehealth = 100;
   

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage(float damage)
    {
       
        zombiehealth -= damage;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {


        if (collision.gameObject.CompareTag("ArBullet")) { GetComponent<ZombieTakeDamage>().TakeDamage(40);}

    }
}
