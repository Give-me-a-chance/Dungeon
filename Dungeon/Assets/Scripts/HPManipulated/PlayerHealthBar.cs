using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerHealthBar : MonoBehaviour
{
    public Slider healthSlider;

    public void ChangeValue(float damage)
    {
        // if (healthSlider.value > 0)
        healthSlider.value -= damage;
    }
    public void UpValue(float damage)
    {
        healthSlider.value += damage;
    }
}
