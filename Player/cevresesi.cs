using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class çevresesi : MonoBehaviour
{
    public GameObject player;
    public LayerMask playerLayer;
    public Transform audiosourcetransform;
    AudioSource audioSource;
    public float range = 5f;
    
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.enabled = false;
        player = GameObject.FindGameObjectWithTag("Player");

    }

    void Update()
    {
        PlayMusic();
        if (Vector2.Distance(transform.position, player.transform.position) < 1)
        {
            audioSource.volume = 1f;
        }
        else if(Vector2.Distance(transform.position, player.transform.position) > 1 && Vector2.Distance(transform.position, player.transform.position) < 2)
        {
            audioSource.volume = 0.5f;
        }
        else if (Vector2.Distance(transform.position, player.transform.position) > 2 && Vector2.Distance(transform.position, player.transform.position) < 5)
        {
            audioSource.volume = 0.2f;
        }
        else if (Vector2.Distance(transform.position, player.transform.position) >= 5)
        {
            audioSource.volume = 0f;
            audioSource.enabled = false;
        }




    }




    void OnDrawGizmosSelected()
    {
       if(audiosourcetransform == null) { return; }

        Gizmos.DrawWireSphere(audiosourcetransform.position, range);
    }
    void PlayMusic()
    {
        Collider2D[] findplayers = Physics2D.OverlapCircleAll(audiosourcetransform.position, range, playerLayer);
       
        if(findplayers.Length > 0) 
        {
         audioSource.enabled = true;
          
        }
        else { audioSource.enabled = false; }
    }
    

}
