using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Colisions : MonoBehaviour
{

    public bool isGrounded;
    public Transform groundCheck;
    public float groundCheckRadius;
    public LayerMask groundLayer;

    BoxCollider2D col2D;
    private void Awake()
    {
        col2D = GetComponent<BoxCollider2D>();
    }
    
    
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
             
    
   }
    public bool Grounded()
    {


        //isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);
        Vector2 footLeft = new Vector2(col2D.bounds.center.x - col2D.bounds.extents.x, col2D.bounds.center.y);
        Vector2 footRight = new Vector2(col2D.bounds.center.x + col2D.bounds.extents.x, col2D.bounds.center.y);

        Debug.DrawRay(footLeft, Vector2.down * col2D.bounds.extents.y * 1.5f, Color.magenta);
        Debug.DrawRay(footRight, Vector2.down * col2D.bounds.extents.y * 1.5f, Color.magenta);

        if(Physics2D.Raycast(footLeft, Vector2.down, col2D.bounds.extents.y * 1.5f, groundLayer))

        {
            isGrounded = true;

        }

        else if(Physics2D.Raycast(footLeft, Vector2.down, col2D.bounds.extents.y * 1.5f, groundLayer))
        {
            isGrounded = true;
        }
        else
        {
            isGrounded = false;
        }

        return isGrounded;

    }




    private void FixedUpdate()
    {

        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);


    }


} 
    