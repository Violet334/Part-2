using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bar : MonoBehaviour
{
    public Slider slider;

    public void Happy(float value)
    {
        slider.value += value;
    }

    public void SetBar(float value)
    {
        slider.value = value;
    }
}
