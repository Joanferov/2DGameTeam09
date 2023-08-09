using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    protected Animator animator;
    protected Automovement autoMovement;
    protected Rigidbody2D rb2D;

    protected virtual void Awake()
    {

        animator = GetComponent<Animator>();
        autoMovement = GetComponent<Automovement>();
        rb2D = GetComponent<Rigidbody2D>();
    }

    protected virtual void Update()
    {


    }
    public virtual void Stomped()
    {

    }
}
