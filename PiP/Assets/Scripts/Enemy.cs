using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    //Sets the health to an enemy
    public int health = 100;
    //Sets object for creating animation
    public GameObject deathEffect;

    public void TakeDamage(int damage)
    {
        //our health and deacreaing its value
        health -= damage;

        if(health <= 0)
        {
            //method for destroying object
            Die();
        }
    }

    void Die()
    {
        Destroy(gameObject);
    }
}
