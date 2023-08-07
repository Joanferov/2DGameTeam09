using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animations : MonoBehaviour
{
    Animator animator;
    Colisions colisions;
    Movimiento movimiento;
    private void Awake()

    {
        animator = GetComponent<Animator>();
        colisions = GetComponent<Colisions>();
        movimiento = GetComponent<Movimiento>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        animator.SetBool("Grounded", colisions.Grounded());
        animator.SetFloat("Velocity_X", Mathf.Abs(movimiento.rb2D.velocity.x));
        animator.SetBool("Jump", movimiento.isJumping);
        animator.SetBool("Skid", movimiento.isSkidding);
    }
}
