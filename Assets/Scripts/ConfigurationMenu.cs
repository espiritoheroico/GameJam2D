using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class ConfigurationMenu : MonoBehaviour
{
    public AudioMixer audiom;
    public void setVolume(float volume)
    {
        audiom.SetFloat("volume", volume);
    }

    public void changeFullScreen(bool type)
    {
        Screen.fullScreen = type;
    }

}
