using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikesHit : MonoBehaviour
{
    void Start()
    {

    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        collision.gameObject.GetComponent<Player>().health = 0;
    }
}
