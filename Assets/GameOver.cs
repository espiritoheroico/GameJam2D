using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public GameObject gameoverpanel;
    public AudioSource gameoversound;

    public void gameover()
    {
        gameoverpanel.gameObject.SetActive(true);
        gameoversound.Play();
    }

    public void menu() 
    {
        SceneManager.LoadScene("menu");
    }

    public void reload()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

}
