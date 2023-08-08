using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mario : MonoBehaviour
{
    public GameObject stompBox;
    Movimiento mover;
    Colisions colisiones;
    Animations animaciones;
    Rigidbody2D rb2D;
    private void Awake()

    {
        mover = GetComponent<Movimiento>();
        colisiones = GetComponent<Colisions>();
        animaciones = GetComponent<Animations>();
        rb2D = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if(rb2D.velocity.y < 0)
        {
            stompBox.SetActive(true);
        }
        else
        {
            stompBox.SetActive(false);
        }

    }


    public void Hit()
    {
        //Debug.Log("Hit");
        Dead();
    }
    public void Dead()
    {
        //mover.inputMoveEnabled = false;
        colisiones.Dead();
        mover.Dead();
        animaciones.Dead();  
    }

}
