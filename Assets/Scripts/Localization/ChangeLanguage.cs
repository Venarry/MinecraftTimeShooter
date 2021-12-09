using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeLanguage : MonoBehaviour
{
    private LanguageSwitcher _language;

    private void Start()
    {
        _language = FindObjectOfType<LanguageSwitcher>();
    }
    public void SwitchToRussian()
    {
        _language.SwitchToRussian();
    }
    public void SwitchToEnglish()
    {
        _language.SwitchToEnglish();
    }
}
