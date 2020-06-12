using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class soundManagerScript : MonoBehaviour
{
    public AudioSource musicIntro;
    public AudioSource musicLoop;
    public AudioSource enemyHitSound;
    public AudioSource hookSound;
    public AudioSource jumpSound;
    public AudioSource killedSound;
    public AudioSource damageSound;
    public AudioSource collectItens;
    //public AudioSource menuChangeSound;
    //public AudioSource menuEnterSound;
    //public AudioSource menuExitSound;

    // Start is called before the first frame update
    void Start()
    {

        musicIntro.Play();
        musicLoop.PlayDelayed(musicIntro.clip.length);
    }

    public void playCollect()
    {
        collectItens.Play();
    }
    public void playEnHit()
    {
        enemyHitSound.Play();
    }
    public void playHook()
    {

        hookSound.Play();
    }
    public void playJump()
    {
        jumpSound.Play();
    }
    public void playDamage()
    {
        damageSound.Play();
    }
    public void playKilled()
    {
        killedSound.Play();
    }
}
