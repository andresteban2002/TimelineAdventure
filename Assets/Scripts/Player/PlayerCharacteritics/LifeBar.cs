using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifeBar : MonoBehaviour
{
    public static LifeBar instance;
    public Slider slider;
    NicknameData data;
    // Start is called before the first frame update
    void Start()
    {
        GameObject gameObject = GameObject.Find("LifeBar");
        if (gameObject != null)
        {
            slider = gameObject.GetComponent<Slider>();
        }
    }

    // Update is called once per frame
    public void ChangeMaxLife(float vidaMaxima)
    {
        if (slider != null)
        {
            slider.maxValue = vidaMaxima;
        }
    }

    public void ChangeCurrentLife(float cantidadVida)
    {
        if (slider != null)
        {
            slider.value = cantidadVida;
        }
    }

    public void StartLifeBar(float cantidadVida)
    {
        ChangeMaxLife(cantidadVida);
        ChangeCurrentLife(cantidadVida);
    }
    
    private void Awake()
    {
        instance = this;
    }
}
