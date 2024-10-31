using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HealthUI : MonoBehaviour
{

    [SerializeField] Slider _slider;
    [SerializeField] TextMeshProUGUI _text;
    [SerializeField] EntityHealth _playerHealth;

    private void Awake()
    {
        _playerHealth.OnHealthChange += UpdateSlider;
        _playerHealth.OnHealthMaxChange += UpdateCached;
    }

    private void Start()
    {
        UpdateSlider(_playerHealth.CurrentHealth);
    }

    void UpdateCached(int value)
    {
        _slider.maxValue = value;
        UpdateSlider(_playerHealth.CurrentHealth);
    }

    void UpdateSlider(int newHealthValue)
    {
        _slider.value = newHealthValue;
        _text.text = $"{_slider.value} / {_slider.maxValue}";
    }

}
