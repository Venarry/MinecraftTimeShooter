using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameLocalization : MonoBehaviour
{
    [SerializeField] private Text _winLabel;
    [SerializeField] private Text _loseLabel;
    [SerializeField] private Text _FAQ;

    private LanguageSwitcher _language;

    private void Awake()
    {
        _language = GetComponent<LanguageSwitcher>();
        _language.SwitchLanguage += ChangeLabel;
    }

    private void ChangeLabel()
    {
        _winLabel.text = _language.WinLabel;
        _loseLabel.text = _language.LoseLabel;
        _FAQ.text = _language.FAQ;
    }

    private void OnDisable()
    {
        _language.SwitchLanguage -= ChangeLabel;
    }
}
