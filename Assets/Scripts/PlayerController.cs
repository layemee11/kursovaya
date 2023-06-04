using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public GameObject panel;
    public float health;
    public int numOfHearts;
    public Image[] hearts;
    public Sprite fullHeart;
    public Sprite emptyHeart;
    public float heal;
    public float speed;
    public float jumpForce;
    private float moveInput;

    private Rigidbody2D rb;

    private bool facingRight = true;

    private bool isGrounded;
    public Transform feetPos;
    public float checkRadius;
    public LayerMask whatIsGround;

    private Animator anim;
    private bool isNearNoSon = false;

    public GameObject cutsceneDirectorObject;

    private PlayableDirector cutsceneDirector;
    private bool canMove = true;

    private void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();

        cutsceneDirector = cutsceneDirectorObject.GetComponent<PlayableDirector>();
    }


    private void FixedUpdate()
    {
        if (health > numOfHearts)
        {
            health = numOfHearts;
        }
        health += Time.deltaTime * heal;
        for (int i = 0; i < hearts.Length; i++)
        {
            if (i < Mathf.RoundToInt(health))
            {
                hearts[i].sprite = fullHeart;
            }
            else
            {
                hearts[i].sprite = emptyHeart;
            }
            if (i < numOfHearts)
            {
                hearts[i].enabled = true;
            }
            else
            {
                hearts[i].enabled = false;
            }
        }

        if (!canMove) 
        {
            rb.velocity = Vector2.zero; 
            return; 
        }

        moveInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);
        if (facingRight == false && moveInput > 0)
        {
            Flip();
        }
        else if (facingRight == true && moveInput < 0)
        {
            Flip();
        }
    }

    private void Update()
    {
        if (transform.position.y < -190)
        {
            health = 0;
        }

        if (health <= 0)
        {
            anim.SetTrigger("die");
            panel.SetActive(true);
            Destroy(gameObject);
        }

        isGrounded = Physics2D.OverlapCircle(feetPos.position, checkRadius, whatIsGround);
        if (isGrounded == true && Input.GetKeyDown(KeyCode.Space))
        {
            rb.velocity = Vector2.up * jumpForce;
        }
        if (isNearNoSon && Input.GetKeyDown(KeyCode.E))
        {
            cutsceneDirector.Play(); // Запускаем катсцену

            // Блокируем движение игрока
            canMove = false;

            //GetComponent<BoxCollider2D>().enabled = false;
        }
    }

    void Flip()
    {
        facingRight = !facingRight;
        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("NoSon"))
        {
            isNearNoSon = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("NoSon"))
        {
            isNearNoSon = false;
        }
    }
    public void TakeDamage(int damage)
    {
        health -= damage;
    }

    public void DisableMovement()
    {
        canMove = false;
        rb.velocity = Vector2.zero;
    }

    public void EnableMovement()
    {
        canMove = true;
    }
}
