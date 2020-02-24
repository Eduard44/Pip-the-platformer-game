using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*public class PlayerMovement : MonoBehaviour
{
    public float speed = 10.0f;
    public bool isGrounded = false;
    public Vector2 jumpVector = new Vector2 (0f,10f);
    void Update()
    {
        
        // Get the horizontal and vertical axis.
        // By default they are mapped to the arrow keys.
        // The value is in the range -1 to 1
        float leftRight = Input.GetAxis("Horizontal") * speed;


        // Make it move 10 meters per second instead of 10 meters per 

frame...
        leftRight *= Time.deltaTime;

        // Move translation along the object's z-axis
        transform.Translate(leftRight, 0, 0);
        Jump();

    }
    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded == true)
        {
            gameObject.GetComponent<Rigidbody2D>().AddForce(jumpVector, 

ForceMode2D.Impulse);
        }
    }

    
}*/
public class PlayerMovement : MonoBehaviour
{
    // paramater of speed variable
    public float speed = 10;
    public Vector2 jumpVector = new Vector2(0f, 10f);
    public bool isGrounded = false;
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
}
