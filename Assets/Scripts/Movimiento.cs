using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimiento : MonoBehaviour
{
    enum Direction { Left= -1,None= 0,Right = 1};
    Direction currentDirection = Direction.None;


    public float speed;

    public Rigidbody2D rb2D;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        currentDirection = Direction.None;
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
            //transform.Translate(-speed, 0, 0);
            currentDirection = Direction.Left;
        }

            if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {

            // transform.Translate(speed, 0, 0);

            currentDirection = Direction.Right;


        }
            

            }

    private void FixedUpdate()
    {

        Vector2 velocity = new Vector2((int)currentDirection*speed, rb2D.velocity.y);
        rb2D.velocity = velocity;

    }

            void Jump()
{
    Vector2 fuerza = new Vector2(0, 10f);
    rb2D.AddForce(fuerza, ForceMode2D.Impulse);
}

            void MoveRight()
    {

        Vector2 velocity = new Vector2(1f, 0f);
        rb2D.velocity = velocity;


    }




        }



    

