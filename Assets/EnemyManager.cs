using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    GameObject player;
    float speed = 0;

    float tempoatual = 0;
    float tempoantigo = 0;
    float intervalo = 1;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        tempoatual += Time.deltaTime;
        if((tempoatual - tempoantigo) > intervalo)
        {
            tempoantigo = tempoatual;
            speed = Random.Range(-2, 2);
        }

        transform.Translate(speed * 2 * Time.deltaTime, 0, 0);

        if (Vector2.Distance(transform.position, player.transform.position) < 1) 
        {
            player.GetComponent<PlayerManager>().TakeDamageLife(1);
        }

    }
}
