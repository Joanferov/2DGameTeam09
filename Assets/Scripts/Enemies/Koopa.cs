using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Koopa : Enemy
{

    bool isHidden;
    public float maxStoppedTime;
    float StoppedTimer;

    protected override void Update()
    {
        base.Update();
        if(isHidden && rb2D.velocity.x == 0f)
        {
            StoppedTimer += Time.deltaTime;
            if(StoppedTimer >= maxStoppedTime)
            {
                ResetMove();
            }
        }

    }

    public override void Stomped()
    {
        if(!isHidden)
        {
            isHidden = true;
            animator.SetBool("Hidden", isHidden);
            autoMovement.PauseMovement();
        }
        gameObject.layer = LayerMask.NameToLayer("OnlyGround");

        Invoke("ResetLayer", 0.1f);
        StoppedTimer = 0;
    }

    void ResetLayer()
    {
        gameObject.layer = LayerMask.NameToLayer("Enemy");
    }
    void ResetMove()
    {
        autoMovement.ContinueMovement();
        isHidden = false;
        animator.SetBool("Hidden", isHidden);
        StoppedTimer = 0;

    }
}
