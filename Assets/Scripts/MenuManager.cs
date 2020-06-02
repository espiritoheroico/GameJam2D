using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MenuManager : MonoBehaviour
{
    [SerializeField] GameObject panel;

    private void Start()
    {
        panel.gameObject.SetActive(false);
    }

    public void PlayGame()
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
