using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Video;

public class MenuManager : MonoBehaviour
{
    [SerializeField] GameObject panel;
    public VideoPlayer video;
    public RawImage img;

    private void Start()
    {
        panel.gameObject.SetActive(false);
        img.enabled = false;
        video.loopPointReached += CheckOver;
    }

    public void PlayGame()
    {
        video.Play();
        img.enabled = true;
    }

    void CheckOver(UnityEngine.Video.VideoPlayer vp)
    {
        SceneManager.LoadScene("Fase1");
    }

    public void ExitGame()
    {
        Application.Quit();
    }
    public void ConfigMenu()
    {
        panel.gameObject.SetActive(true);
    }

    public void closeConfigMenu() 
    {
        panel.gameObject.SetActive(false);
    }
}
