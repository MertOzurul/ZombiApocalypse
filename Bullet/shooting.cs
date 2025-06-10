using System.Collections;
using System.Collections.Generic;
using UnityEditor.PackageManager;
using UnityEngine;
using UnityEngine.InputSystem;

public class shooting : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletprefab;
    public float bulletforce = 20f;
    


    private bool isReloading;
    public int kullanilanmermi;
    public int anasarjor = 30;
    public int yansarjor = 60;
    public int toplammermi;
    private void Start()
    {
     
        
    }
    void Update()
    {
        
        toplammermi = anasarjor + yansarjor;
        if (toplammermi > 0 && yansarjor >= 0)
        {
       
            if (Input.GetKeyDown(KeyCode.R) && !isReloading)
            {
                StartCoroutine(Reload());
            }
            if(anasarjor == 0) { StartCoroutine(Reload()); }


        }

        



    }
    void OnFire()
    {
        
        if (anasarjor > 0 && !isReloading)
        {
            

             anasarjor--;
            kullanilanmermi++;
            
           GameObject bullet = Instantiate(bulletprefab, firePoint.position, firePoint.rotation);
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();

      



            rb.AddForce(firePoint.up* bulletforce, ForceMode2D.Impulse);

            

        
        }

       

        
    }

    IEnumerator Reload()
    {


        
        isReloading = true;
        yield return new WaitForSeconds(2f);
        
       if(kullanilanmermi > yansarjor ) { anasarjor += yansarjor; yansarjor = 0; } else { anasarjor += kullanilanmermi; yansarjor -= kullanilanmermi; }
  


        kullanilanmermi = 0;




        isReloading = false;
    }



 

}