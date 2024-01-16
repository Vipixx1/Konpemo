using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Slider slider;
    [SerializeField] private Konpemo konpemo;

    private void Start()
    {
        this.slider.maxValue = konpemo.health.BaseValue;
        this.slider.value = konpemo.health.Value;
    }
    private void Update()
    {
        this.slider.maxValue = konpemo.health.BaseValue;
        this.slider.value = konpemo.health.GetCurrentHealth();

    }
}
