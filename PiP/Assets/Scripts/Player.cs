using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // this is to understand where the mouse to look at;
    private Vector2 lookDirection;

    //this initializes things that go on starting the game
    private void Start()
    {

        //to not destroy the player loading a new level
        DontDestroyOnLoad(gameObject);
    }

    private void FixedUpdate()
    {
        //the direction of the mouse wherever it moves
        lookDirection = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        RotatePlayer(lookDirection);
    }

    void RotatePlayer(Vector2 lookDirection)
    {
        Vector2 playerPosition = gameObject.transform.position;
        //if the mouse looks towards the right of the player or above him
        //we rotate to the right
        if (lookDirection.x >= playerPosition.x)
        {
            transform.localScale = Vector2.one;
        }
        //if the mouse looks to the left of the player 
        //we rotate to the left
        else if (lookDirection.x < playerPosition.x)
        {
            transform.localScale = new Vector2(-1, 1);
        }
    }
}
