using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class PlayerManager : MonoBehaviour
{
    public Hook hook;
    public Text txtIten;
    public Text txtVida;
    public float vida = 100;
    public int totalLifes = 3;
    public float dano = 30;
    public float collectables = 0;
    public float moveSpeed = 5f;
    public float jumpForce = 300f;
    public bool isGrounded;
     float timerJump = 0f;

    SpriteRenderer sprite;
    public SpriteRenderer bracosprite;
    public soundManagerScript soundfx;
    public healthBarControl healthBar;
    Animator anim;
    Transform tr;
    public GameOver go;

    public Rigidbody2D rb;
    [SerializeField]
    float radius = 0.3f;
    [SerializeField] Transform checker;
    [SerializeField] LayerMask layer;

    void Start()
    {
        txtVida.text = totalLifes.ToString();
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
        tr = GetComponent<Transform>();
    }

    void Update()
    {
        //move
        Vector2 movement = new Vector2(Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime, 0);
        transform.Translate(movement);

        //flip
        if (Input.GetAxis("Horizontal") > 0)
        {
            sprite.flipX = false;
            bracosprite.flipX = false;
            anim.SetFloat("movement", 1);
        }
        else if (Input.GetAxis("Horizontal") < 0)
        {
        sprite.flipX = true;
        bracosprite.flipX = true;
        anim.SetFloat("movement", 1); 
        }
        else anim.SetFloat("movement", 0);

        //jump
        isGrounded = Physics2D.OverlapCircle(checker.transform.position, radius, layer);

        if (isGrounded && Input.GetAxis("Vertical") > 0)
        {
            if (timerJump <= 0.0f)
            {
                soundfx.playJump();
                timerJump = 0.5f;
            }
            Jump(jumpForce);
            anim.SetTrigger("jump");
        }
        timerJump -= Time.deltaTime;
    }

    public void TakeDamageLife(float value)
    {
        soundfx.playDamage();
        vida -= value;
        healthBar.SetHealth(vida);
    }
    
    void IncreaseLife(float value)
    {
        vida += value;
        healthBar.SetHealth(vida);
    }

    void Die()
    {
        soundfx.playKilled();
        hook.DisableHook();
        gameObject.transform.position = new Vector2(-100, 0);
        vida = 100;
        healthBar.SetHealth(vida);
        totalLifes--;
        txtVida.text = totalLifes.ToString();
        if (totalLifes < 0) GameOver();

    }
    void GameOver()
    {
        go.gameover();
    }
    void Jump(float jumpF)
    {
        rb.AddForce(Vector2.up * jumpF * Time.deltaTime, ForceMode2D.Impulse);
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(checker.transform.position, radius);
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if ((col.collider.tag) == "Spike")
        {
            TakeDamageLife(dano);
            sprite.color = Color.red;
            Jump(500);
            anim.SetTrigger("jump");
            if (vida <= 0)
                Die();
        }

    }
    private void OnCollisionExit2D(Collision2D col)
    {
        if ((col.collider.tag) == "Spike")
        {
            sprite.color = Color.white;
        }

    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Collect")
        {
            soundfx.playCollect();
            collectables++;
            txtIten.text = collectables.ToString();
            Destroy(col.gameObject);
        }
    }
}