using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimiento : MonoBehaviour
{
    enum Direction { Left = -1, None = 0, Right = 1 };
    Direction currentDirection = Direction.None;


    public float speed;
    public float acceleration;
    public float maxVelocity;
    public float friction;
    float currentVelocity = 0f;


    public float jumpForce;
    public float maxJumpingTime = 1f;
    public bool isJumping;
    float jumpTimer = 0;
    float defaultGravity;

    public bool isSkidding;
    public Rigidbody2D rb2D;
    Colisions colisions;

    public bool inputMoveEnabled = true;
    private void Awake()

    {
        rb2D = GetComponent<Rigidbody2D>();
        colisions = GetComponent<Colisions>();

    }

    // Start is called before the first frame update
    void Start()
    {
        defaultGravity = rb2D.gravityScale;
    }

    // Update is called once per frame
    void Update()
    {

        if (isJumping)
        {
            /* if(rb2D.velocity.y < 0f)
             {
                 rb2D.gravityScale = defaultGravity;
                 if(colisions.Grounded())
                 {
                     isJumping = false;
                     jumpTimer = 0;
                 }

             }*/
            if (rb2D.velocity.y > 0f)
            {

                if (Input.GetKey(KeyCode.Space))
                {
                    jumpTimer += Time.deltaTime;

                }
                if (Input.GetKeyUp(KeyCode.Space))
                {
                    if (jumpTimer < maxJumpingTime)
                    {
                        rb2D.gravityScale = defaultGravity * 3f;
                    }

                }
            }
            else

            {
                rb2D.gravityScale = defaultGravity;
                if (colisions.Grounded())
                {
                    isJumping = false;
                    jumpTimer = 0;
                }

            }



        }

        currentDirection = Direction.None;

        if (inputMoveEnabled)
        {

            if (Input.GetKeyDown(KeyCode.Space))
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




    }

    private void FixedUpdate()
    {
        /*Vector2 forceAcceleration = new Vector2((int)currentDirection * acceleration, 0f);
        rb2D.AddForce(forceAcceleration);
        float velocityX = Mathf.Clamp(rb2D.velocity.x, -maxVelocity, maxVelocity);

        Vector2 velocity = new Vector2(velocityX, rb2D.velocity.y);
        rb2D.velocity = velocity;
        */

        isSkidding = false;
        currentVelocity = rb2D.velocity.x;
        if (currentDirection > 0)
        {
            if (currentVelocity < 0)
            {
                currentVelocity += (acceleration + friction) * Time.deltaTime;
                isSkidding = true;
            }
            else if (currentVelocity < maxVelocity)
            {

                currentVelocity += acceleration * Time.deltaTime;
                transform.localScale = new Vector2(1, 1);
            }
        }
        else if (currentDirection < 0)

        {

            if (currentVelocity > 0)
            {
                currentVelocity -= (acceleration + friction) * Time.deltaTime;
                isSkidding = true;

            }
            else if (currentVelocity > -maxVelocity)
            {
                currentVelocity -= acceleration * Time.deltaTime;
                transform.localScale = new Vector2(-1, 1);
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
        if (colisions.Grounded() && !isJumping)
        {
            isJumping = true;
            Vector2 fuerza = new Vector2(0, jumpForce);
            rb2D.AddForce(fuerza, ForceMode2D.Impulse);

        }

    }

    void MoveRight()
    {

        Vector2 velocity = new Vector2(1f, 0f);
        rb2D.velocity = velocity;


    }


    public void Dead()
    {
        inputMoveEnabled = false;
        rb2D.velocity = Vector2.zero;
        rb2D.gravityScale = 1;
        rb2D.AddForce(Vector2.up * 5f, ForceMode2D.Impulse);
    }

    public void BounceUp()
    {
        rb2D.velocity = Vector2.zero;
        //Vector2 forceUp = new Vector2(0, 10f);
        rb2D.AddForce(Vector2.up * 10f, ForceMode2D.Impulse);

    }




}



    

