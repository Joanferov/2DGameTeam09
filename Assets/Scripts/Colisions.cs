using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Colisions : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
             
    
   }
    /* private void OnCollisionEnter2D(Collision2D collision)
     {
         if (collision.gameObject.CompareTag("Pipe"))
         {
             Debug.Log("Collision Enter: " + collision.gameObject.name);

         }
         else if (collision.gameObject.CompareTag("Ground"))
         {

             Debug.Log("Empezamos a tocar el suelo");
         }
     }

     private void OnCollisionStay2D(Collision2D collision)
     {
         if (collision.gameObject.tag == "Pipe")
         {
             Debug.Log("Collision Stay:" + collision.gameObject.name);

         }

     }

     private void OnCollisionExit2D(Collision2D collision)
     {
         if (collision.gameObject.CompareTag("Pipe"))
         {

             Debug.Log("Collision Exit:" + collision.gameObject.name);


         }
         else if (collision.gameObject.CompareTag("Ground"))
         {

             Debug.Log("Dejamos de tocar el suelo");
         }
     }*/

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {

            Debug.Log("Empezamos a tocar el suelo");
        }

    }
    private void OnTriggerStay2D(Collider2D collision)
        {

        }
    private void OnTriggerExit2D(Collider2D collision)
    { 
        if (collision.gameObject.CompareTag("Ground"))
        {

            Debug.Log("Dejamos de tocar el suelo");
        }
   

    }

}
