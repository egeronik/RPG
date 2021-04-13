using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider slider;
    public Gradient gradient;
    public Image fill;
    public void SetMaxHealth (int healt) {
        slider.maxValue = healt;
        slider.value = healt;

        fill.color = gradient.Evaluate(1f);
    }
    public void SetHealt (int healt) {
        slider.value = healt;
        fill.color = gradient.Evaluate(slider.normalizedValue);
    }
}
