using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireAtMousePosition : MonoBehaviour
{
    public Transform endPointOfWeapon;
    public GameObject bullet;
    public float speed = 10f;
    private Vector2 lookDirection;

    private float lookAngle;

    void Update()
    {
        lookDirection = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        lookAngle = Mathf.Atan2(lookDirection.y, lookDirection.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, lookAngle - 90f);
        if (Input.GetMouseButtonDown(0))
        {
            FireBullet();
        }
    }

    void FireBullet()
    {
        GameObject fireBullet = Instantiate(bullet, endPointOfWeapon.position, endPointOfWeapon.rotation);
        fireBullet.GetComponent<Rigidbody2D>().velocity = endPointOfWeapon.up * speed;
    }
}
