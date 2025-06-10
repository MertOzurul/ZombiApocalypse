using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class walksound : MonoBehaviour
{
    [SerializeField] float speed = 10f;
    AudioSource audioSource;
    Rigidbody2D rb;
    float x;
    float y;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        y = Input.GetAxis("Vertical") * speed;
        x = Input.GetAxis("Horizontal") * speed;
        rb.velocity = new Vector2(x, y);
        if(rb.velocity.x != 0 || rb.velocity.y != 0)
        {
            if (!audioSource.isPlaying) { audioSource.Play(); }
        }
        else { audioSource.Stop(); }
        
        
    }
}
