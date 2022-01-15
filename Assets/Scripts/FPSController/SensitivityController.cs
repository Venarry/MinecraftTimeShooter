using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SensitivityController : MonoBehaviour
{
    private Slider _slider;
    private void Start()
    {
        _slider = GetComponent<Slider>();

        if (PlayerPrefs.HasKey("Sensitivity"))
        {
            float _savedSensitivity = PlayerPrefs.GetFloat("Sensitivity");
            ChangeSensitivity(_savedSensitivity);
            _slider.value = _savedSensitivity;
        }
        else
            ChangeSensitivity(0.5f);
    }
    public void ChangeSensitivity(float sensitivity)
    {
        PlayerPrefs.SetFloat("Sensitivity", sensitivity);
    }
}
