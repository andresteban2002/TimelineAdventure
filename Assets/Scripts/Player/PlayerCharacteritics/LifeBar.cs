using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifeBar : MonoBehaviour
{

    private Slider slider;
    // Start is called before the first frame update
    void Start()
    {
        slider = GetComponent<Slider>();
    }

    // Update is called once per frame
    public void ChangeMaxLife(float vidaMaxima)
    {
        slider.maxValue = vidaMaxima;
    }
    
    public void ChangeCurrentLife(float cantidadVida)
    {
        slider.value = cantidadVida;
    }

    public void StartLifeBar(float cantidadVida)
    {
        ChangeMaxLife(cantidadVida);
        ChangeCurrentLife(cantidadVida);
    }
}
