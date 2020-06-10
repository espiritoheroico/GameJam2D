using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class enemyDeathManager : MonoBehaviour
{

    float enemyLife = 100;
    SpriteRenderer sprite;
    Transform tr;
    GameObject parent;
    public soundManagerScript soundfx;
    // Start is called before the first frame update
    void Start()
    {
        tr = GetComponent<Transform>();
        parent = tr.parent.gameObject;
        sprite = parent.GetComponent<SpriteRenderer>();
    }


    void Die()
    {
        Destroy(parent);
        soundfx.playKilled();
    }
    void TakeDamageLife(float value)
    {
        enemyLife -= value;
    }
    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            TakeDamageLife(34);
            soundfx.playEnHit();

            sprite.color = Color.red;
            if (enemyLife <= 0)
                Die();
        }

    }
    private void OnCollisionExit2D(Collision2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            sprite.color = Color.white;
        }

    }
}
