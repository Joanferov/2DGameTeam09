using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Automovement : MonoBehaviour
{
    public float speed = 1f;
    bool movementPaused;
    Rigidbody2D rb2D;

    private void Awake()
    {
        rb2D = GetComponent<Rigidbody2D>();

    }

    private void Start()
    {
        rb2D.velocity = new Vector2(speed, rb2D.velocity.y);


    }



    private void FixedUpdate()
    {
        if(!movementPaused)
        {

            if (rb2D.velocity.x > -0.1f && rb2D.velocity.x < 0.1f)
            {
                speed = -speed;

            }

            rb2D.velocity = new Vector2(speed, rb2D.velocity.y);
 


        }




    }
    public void PauseMovement()
    {
        if(!movementPaused)
        {
            movementPaused = true;
            rb2D.velocity = new Vector2(0, 0);

        }
    }


}