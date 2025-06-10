using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

 
public class PlayerInputScript : MonoBehaviour
{
    public Vector2 velocity;
    public Animator animator;
    Rigidbody2D rb;
    public int moveSpeed = 10;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void OnMove(InputValue movementInput)
    {
        velocity = movementInput.Get<Vector2>();

    }


    void Update()
    {
        if (velocity != Vector2.zero)
        {
            rb.MovePosition(rb.position + velocity * moveSpeed * Time.fixedDeltaTime);


            
        }
 



    }



  

}
