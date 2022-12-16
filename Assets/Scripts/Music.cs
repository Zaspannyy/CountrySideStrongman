using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Music : MonoBehaviour
{
    public Sprite onMusic;
    public Sprite offMusic;

    public Image MusicButton;
    public bool isOn;
    public AudioSource ad;



    void Start()
    {
        isOn = true;
    }

    private void SoundOn()
    {
       MusicButton.GetComponent<Image>().sprite = onMusic;
        ad.enabled = true;
        isOn = true;
    }

    private void SoundOff()
    {
        MusicButton.GetComponent<Image>().sprite = offMusic;
        ad.enabled = false;
        isOn = false;
    }
    public void SoundChange()
    {
        if (isOn)
        {
            SoundOff();
        }
        else { SoundOn(); }
    }

}