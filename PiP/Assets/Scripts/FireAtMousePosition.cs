using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireAtMousePosition : MonoBehaviour
{
    //This is the place where it will shootfrom. The weapon's end
    public Transform endPointOfWeapon;
    //This is not needed anymore since we dont have bullets. Read down to understand.
    // public GameObject bullet;
    //public float speed = 10f;

        // this is to understand where the mouse to look at;
    private Vector2 lookDirection;
       // this is for the weapon to change its rotation. 
    private float lookAngle;
    //variable for our damage
    public int damage = 40;
    //this is for our "bullet" which is raycast and needs to be seen so I am seeting a line for the bullet;
    public LineRenderer lineRenderer;
    void Update()
    {
        //This is changing the vector2 we made earlier to the point of the mouse in the world.
        lookDirection = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        //this is the rotation we need to rotate our weapon.
        lookAngle = Mathf.Atan2(lookDirection.y, lookDirection.x) * Mathf.Rad2Deg;
        //this is changing the rotation of our weapon.
        transform.rotation = Quaternion.Euler(0f, 0f, lookAngle - 90f);

        //this checks if we got our mouse left buttong down.
        if (Input.GetMouseButtonDown(0))
        {
            //Method for shooting.
            FireBullet();
        }
    }

    void FireBullet()
    {
        //This is shooting with rayCast which is ray that checks if it hits something or not. We are using
        //shotgun, so we dont need bullets at the moment. We will use only animation and raycast.

        //Direction of hitting and creating RayCast
        RaycastHit2D hitAndInfo = Physics2D.Raycast(endPointOfWeapon.position, lookDirection);

        //if we hit something = true
        if (hitAndInfo)
        {
            // just information about the enemy script, which we get by getComponent and we take the health.
            Enemy enemy = hitAndInfo.transform.GetComponent<Enemy>();
            if(enemy != null)
            {
                //method from Enemey script
                enemy.TakeDamage(damage);
            }
            //This is me trying to draw line from start to end so we can see the direction of RayCast
            //For some reason it doesnt work gonna fix it later.
            lineRenderer.SetPosition(0, endPointOfWeapon.position);
            lineRenderer.SetPosition(1, hitAndInfo.point);

        }//else
        //{
        //    lineRenderer.SetPosition(0, endPointOfWeapon.position);
        //    lineRenderer.SetPosition(1, endPointOfWeapon.position * 100);
        //}
        //This is the old way of shooting with a physical bullet.
        //GameObject fireBullet = Instantiate(bullet, endPointOfWeapon.position, endPointOfWeapon.rotation);
        //fireBullet.GetComponent<Rigidbody2D>().velocity = endPointOfWeapon.up * speed;
    }
}
