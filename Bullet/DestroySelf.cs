using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroySelf : MonoBehaviour
{
    // Start is called before the first frame update

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(Destroy());
    }
     void OnCollisionEnter2D(Collision2D collision)
    {
         Destroy(gameObject); 

     

    }
    IEnumerator Destroy() { 
    
    yield return new WaitForSeconds(1.0f);
        Destroy (gameObject);
    
    }
}
