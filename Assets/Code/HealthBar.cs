/*
 * Author: 
 * Date: 23 June 2024
 * Description: 
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HealthBar : MonoBehaviour
{
    public Slider healthSlider;

    public TextMeshProUGUI healthText;

    public void SetSlider(float amount)
    {
        healthSlider.value = amount;
        UpdateHealthText(amount);
    }

    public void SetSliderMax(float amount)
    {
        healthSlider.maxValue = amount;
        SetSlider(amount);
    }

    private void UpdateHealthText(float amount)
    {
        healthText.text = $"{amount}/{healthSlider.maxValue}";
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
