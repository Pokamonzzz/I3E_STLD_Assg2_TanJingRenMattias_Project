/*
 * Author: Tan Jing Ren Mattias
 * Date: 26 June 2024
 * Description: Manages the UI health bar display with a slider and text for player health.
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HealthBar : MonoBehaviour
{
    /// <summary>
    /// Reference to the slider component for health display.
    /// </summary>
    public Slider healthSlider;

    /// <summary>
    /// Reference to the TextMeshPro component for health display text.
    /// </summary>
    public TextMeshProUGUI healthText;

    /// <summary>
    /// Updates the health slider value and health text display.
    /// </summary>
    /// <param name="amount">The current health amount to display.</param>
    public void SetSlider(float amount)
    {
        healthSlider.value = amount;
        UpdateHealthText(amount);
    }

    /// <summary>
    /// Sets the maximum value of the health slider.
    /// </summary>
    /// <param name="amount">The maximum health amount.</param>
    public void SetSliderMax(float amount)
    {
        healthSlider.maxValue = amount;
        SetSlider(amount);
    }

    /// <summary>
    /// Updates the health text to show current and maximum health.
    /// </summary>
    /// <param name="amount">The current health amount.</param>
    private void UpdateHealthText(float amount)
    {
        healthText.text = $"{amount}/{healthSlider.maxValue}";
    }
}