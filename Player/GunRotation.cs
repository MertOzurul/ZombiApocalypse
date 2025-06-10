using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunRotation : MonoBehaviour
{
    public GameObject Player;
    
    void Start()
    {
   

    }

    // Update is called once per frame
    void Update()
    {


        FlipGun();


    }

    void FlipGun()
    {

        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0f;
        

        if (mousePosition.x > Player.transform.position.x) { Player.transform.localScale = new Vector2(1,1);  }
        else if (mousePosition.x < Player.transform.position.x) { Player.transform.localScale = new Vector2(-1, 1); ; }

    }
}
