using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private float timeBtwAttack;
    public float startTimeBtwAttack;

    private Rigidbody2D physic;
    public int health;
    public float speed;
    public float agroDistance;
    public int damage;
    public float stopTime;
    public float startStopTime;
    public float normalSpeed;
    private Transform player;
    private Animator anim;
    private PlayerController playerController;

    void Start()
    {
        anim = GetComponent<Animator>();
        playerController = FindObjectOfType<PlayerController>();
        physic = GetComponent<Rigidbody2D>();
        normalSpeed = speed;
        player = playerController.transform;
    }

    void Update()
    {
        if (stopTime <= 0)
        {
            speed = normalSpeed;
        }
        else
        {
            speed = 0;
            stopTime -= Time.deltaTime;
        }
        if (health <= 0)
        {
            Destroy(gameObject);
        }
        if (playerController != null)
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
    }

    void StartHunting()
    {
        if (player.position.x < transform.position.x)
        {
            physic.velocity = new Vector2(-speed, 0);
            transform.localScale = new Vector2(-2, 2);
        }
        else if (player.position.x > transform.position.x)
        {
            physic.velocity = new Vector2(speed, 0);
            transform.localScale = new Vector2(2, 2);
        }
    }

    void StopHunting()
    {
        physic.velocity = Vector2.zero;
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
    }

    public void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (timeBtwAttack <= 0)
            {
                anim.SetTrigger("attackenemy");
            }
            else
            {
                timeBtwAttack -= Time.deltaTime;
            }
        }
    }

    public void OnEnemyAttack()
    {
        PlayerController playerController = player.GetComponent<PlayerController>();
        if (playerController != null)
        {
            playerController.TakeDamage(damage);
            timeBtwAttack = startTimeBtwAttack;
        }
    }
}
