using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimiento : MonoBehaviour
{
    public float speed;

    public Rigidbody2D rb2D;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //transform.Translate(speed, 0, 0);
        /*
        if(Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            transform.Translate(0, speed, 0);
        }
        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {

            transform.Translate(0, -speed, 0);
        */
        if(Input.GetKeyDown(KeyCode.Space))
        {
            Jump();

        }

        
            if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(-speed, 0, 0);

        }

            if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {

            transform.Translate(speed, 0, 0);

        }

            }

            void Jump()
{
    Vector2 fuerza = new Vector2(0, 10f);
    rb2D.AddForce(fuerza, ForceMode2D.Impulse);
}

            void MoveRight()
    {




    }




        }



    

