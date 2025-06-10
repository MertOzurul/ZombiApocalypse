using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interaction : MonoBehaviour
{

    public  Transform PlayerPos;
    public float interactrange;
    public LayerMask Med;
    public LayerMask Ammo;
    public LayerMask LootBox;
    float timer;
   
    public GameObject GunG;
            
    private void Start()
    {
        timer = 0;
    }
   
    void InteractMed()

    {

        Collider2D[] findMed = Physics2D.OverlapCircleAll(PlayerPos.position, interactrange, Med);

        if (findMed.Length > 0)
        {

            if (Input.GetKeyDown(KeyCode.E)) 
            
            
            { 
                
                GetComponent<Player_Health>().medkit+= findMed.Length;


                foreach (Collider2D medCollider in findMed)
                {
                    
                    Destroy(medCollider.gameObject);

                    
                }







            }


        }

    }
    void InteractAmmo()

    {

        Collider2D[] findAmmo = Physics2D.OverlapCircleAll(PlayerPos.position, interactrange, Ammo);

        if (findAmmo.Length > 0)
        {

            if (Input.GetKeyDown(KeyCode.E)) 
            { 
                
                GetComponent<shooting>().yansarjor += findAmmo.Length * Random.Range(1,15); 

                foreach(Collider2D AmmoCollider in findAmmo)
                {

                Destroy(AmmoCollider.gameObject);


                }  

            
            
            }

            




        }

    }

    void InteractLootBox()
    {

        Collider2D[] findLootBox = Physics2D.OverlapCircleAll(PlayerPos.position, interactrange, LootBox);
        if (findLootBox.Length > 0)
        {

            if (Input.GetKey(KeyCode.E))
            {

                timer += Time.deltaTime;

                if (timer > 3)
                {
                    foreach (Collider2D LootBoxCollider in findLootBox)
                    {

                        int Lootchance = Random.Range(1, 100);


                        if (Lootchance >= 1 && Lootchance <= 45) { GetComponent<shooting>().yansarjor +=  Random.Range(20, 35); }
                        else if (Lootchance >= 46 && Lootchance <= 90) { GetComponent<Player_Health>().medkit += 2; } 
                        else { Instantiate(GunG, LootBoxCollider.gameObject.transform.position, transform.rotation); }

                        Destroy(LootBoxCollider.gameObject);


                    }
                }

            }
            else { if(timer > 0) { timer -= Time.deltaTime; } }
        }
    }
    void Update()
    { 
    
        InteractMed();
        InteractAmmo();
        InteractLootBox();
      
      
    }
    void OnDrawGizmos()
    {
        

        Gizmos.DrawWireSphere(PlayerPos.position, interactrange);
    }


    
   
}
