using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Rigidbody2D physic;
    public Transform player;
    public float health;
    public float speed;
    public float agroDistance;
    void Start () 
    {
        physic = GetComponent<Rigidbody2D>();
    }
    void Update ()
    {
        float distToPlayer = Vector2.Distance(transform.position, player.position);

        if (distToPlayer < agroDistance) 
        {
            StartHunting();
        }
        else
        {
            StopHunting();
        }
    }
    void StartHunting()
    {
        if(player.position.x < transform.position.x)
        {
            physic.velocity = new Vector2(-speed, 0);
            transform.localScale = new Vector2(-2, 2);
        }
        else if(player.position.x > transform.position.x)
        {
            physic.velocity = new Vector2(speed, 0);
            transform.localScale = new Vector2(2, 2);
        }
    }
    void StopHunting()
    {
        physic.velocity = new Vector2(0, 0);
    }
    public void TakeDamage(int damage)
    {
        health -= damage;
    }
}
