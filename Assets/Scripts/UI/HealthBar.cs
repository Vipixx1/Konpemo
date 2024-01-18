using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Slider slider;
    private Konpemo konpemo;

    private void Start()
    {
        konpemo = this.GetComponentInParent<Konpemo>();

        if (konpemo != null)
        {
            this.slider.maxValue = konpemo.health.BaseValue;
            this.slider.value = konpemo.health.Value;
        }
    }

    private void Update()
    {
        if (konpemo != null)
        {
            this.slider.maxValue = konpemo.health.BaseValue;
            this.slider.value = konpemo.health.GetCurrentHealth();
        }
    }
}
