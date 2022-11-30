using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShieldBar : MonoBehaviour
{
    public Slider slider;

    public void ShieldCD(float cd)
    {
        slider.value = cd;
    }

    public void MaxShielCD(float cd)
    {
        slider.maxValue = cd;
    }
}
