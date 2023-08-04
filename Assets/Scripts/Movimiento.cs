using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimiento : MonoBehaviour
{
    enum Direction { Left= -1,None= 0,Right = 1};
    Direction currentDirection = Direction.None;


    public float speed;
    public float acceleration;
    public float maxVelocity;
    public float friction;
    float currentVelocity = 0f;

    Rigidbody2D rb2D;
    Colisions colisions;
    private void Awake()

    {
        rb2D = GetComponent<Rigidbody2D>();
        colisions = GetComponent<Colisions>();

    }

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
        /*Vector2 forceAcceleration = new Vector2((int)currentDirection * acceleration, 0f);
        rb2D.AddForce(forceAcceleration);
        float velocityX = Mathf.Clamp(rb2D.velocity.x, -maxVelocity, maxVelocity);

        Vector2 velocity = new Vector2(velocityX, rb2D.velocity.y);
        rb2D.velocity = velocity;
        */


        currentVelocity = rb2D.velocity.x;
        if (currentDirection > 0)
        {
            if (currentVelocity < 0)
            {
                currentVelocity += (acceleration + friction) * Time.deltaTime;
            }
            else if (currentVelocity < maxVelocity)
            {

                currentVelocity += acceleration * Time.deltaTime;

            }
        }
        else if (currentDirection < 0)

        {

            if (currentVelocity > 0)
            {
                currentVelocity -= (acceleration + friction) * Time.deltaTime;

            }
            else if (currentVelocity > -maxVelocity)
            {
                currentVelocity -= acceleration * Time.deltaTime;

            }
        }
        else

        {

            if (currentVelocity > 1f)
            {
                currentVelocity -= friction * Time.deltaTime;

            }
            else if (currentVelocity < -1f)
            {
                currentVelocity += friction * Time.deltaTime;

            }
            else
            {
                currentVelocity = 0;
            }
        }
        Vector2 velocity = new Vector2(currentVelocity, rb2D.velocity.y);
        rb2D.velocity = velocity;

    }
            void Jump()
{
    if(colisions.Grounded())
        {
            Vector2 fuerza = new Vector2(0, 10f);
            rb2D.AddForce(fuerza, ForceMode2D.Impulse);

        }
    
}

            void MoveRight()
    {

        Vector2 velocity = new Vector2(1f, 0f);
        rb2D.velocity = velocity;


    }




        }



    

