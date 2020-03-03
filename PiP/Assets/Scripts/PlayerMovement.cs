﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerMovement : MonoBehaviour
{
    // paramater of speed variable
    public float speed = 3;
    public Vector2 jumpVector = new Vector2(0f, 2f);
    public bool isGrounded = false;
    private Vector2 moveDelta;
    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        // making direction by getting speed multiplyed with -1 or 1 ;
        float leftRight = Input.GetAxis("Horizontal") * speed;

        // sync it to frame per second
        leftRight *= Time.deltaTime;

        // Move translation along the object's z-axis
        transform.Translate(leftRight, 0, 0);

        Jump();
    }

    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded == true)
        {
            gameObject.GetComponent<Rigidbody2D>().AddForce(jumpVector,ForceMode2D.Impulse);
        }
    }

    protected virtual void RotatePlayer(Vector2 input)
    {
        moveDelta = new Vector2(input.x, input.y);
        //if we move right we change our sprite facing right
        if (moveDelta.x > 0)
        {
            transform.localScale = Vector2.one;
            Move();
        }
        //if we move left we change our sprite to facing left
        else if (moveDelta.x < 0)
        {
            transform.localScale = new Vector2(-1, 1);
            Move();
        }
        else if (moveDelta.x == 0)
        {
            Stop();
        }
    }

    private void Move()
    {
        animator.SetTrigger("Move");
        animator.SetBool("Stop", false);
    }
    private void Stop()
    {
        animator.SetBool("Stop", true);
    }
}
