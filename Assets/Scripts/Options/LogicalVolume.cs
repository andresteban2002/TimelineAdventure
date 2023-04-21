using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LogicalVolume : MonoBehaviour
{
    public Slider slider;
    public float sliderValue;
    public GameObject imagenMute;
    // Start is called before the first frame update
    void Start()
    {
        slider.value = 0.5f;
        AudioListener.volume = slider.value;
        sliderValue = 0.5f;
        RevisarSiEstoyMute();
    }
    public void ChangeSlider(float valor)
    {
        sliderValue = valor;
        PlayerPrefs.SetFloat("volumenAudio", sliderValue);
        AudioListener.volume = slider.value;
        RevisarSiEstoyMute();
    }

    public void RevisarSiEstoyMute()
    {
        if (sliderValue == 0)
        {
            imagenMute.SetActive(true);;
        }
        else
        {
            imagenMute.SetActive(false);
        }
    }

   
}
