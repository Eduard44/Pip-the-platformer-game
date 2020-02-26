using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // this is to understand where the mouse to look at;
    private Vector2 lookDirection;

    //this is the player SpriteRenderer
    private SpriteRenderer spriteRenderer;

    //this initializes things that go on starting the game
    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();

        //to not destroy the player loading a new level
        DontDestroyOnLoad(gameObject);
    }

    private void FixedUpdate()
    {
        //the direction of the mouse
        lookDirection = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        RotatePlayer(lookDirection);
    }

    void RotatePlayer(Vector2 lookDirection)
    {
        Vector2 playerPosition = gameObject.transform.position;
        //if the mouse looks towards the right of the player or above him we don't turn
        //ergo false flipX in the SpriteRenderer
        if (lookDirection.x >= playerPosition.x)
        {
            spriteRenderer.flipX = false;
        }
        //if the mouse looks to the left of the player we turn 
        //ergo true flipX in the SpriteRenderer
        else if (lookDirection.x < playerPosition.x)
        {
            spriteRenderer.flipX = true;
        }
    }
}
