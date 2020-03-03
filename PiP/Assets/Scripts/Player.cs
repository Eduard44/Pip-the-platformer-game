using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : PlayerMovement
{
    //our player's health
    public float health = 100;

    private void FixedUpdate()
    {
        //the direction of the mouse wherever it moves
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

        RotatePlayer(new Vector2(x, y));

        if(this.health <= 0)
        {
            Destroy(this.gameObject);
        }
    }
}
