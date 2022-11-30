using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider slider;

    public void Heath(int hp)
    {
        slider.value = hp;
    }

    public void MaxHealth(int hp)
    {
        slider.maxValue = hp;
    }
}
