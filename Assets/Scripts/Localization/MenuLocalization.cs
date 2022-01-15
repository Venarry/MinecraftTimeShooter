using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuLocalization : MonoBehaviour
{
    [SerializeField] private Text _levelsLabel;
    [SerializeField] private Text _arenaLabel;
    [SerializeField] private Text _sensitivityLabel;
    [SerializeField] private Text _bestScoreLabel;
    [SerializeField] private Text _musicVolumeLabel;
    [SerializeField] private Text _effectVolumeLabel;

    private LanguageSwitcher _language;

    private void Start()
    {
        _language = FindObjectOfType<LanguageSwitcher>();
        _language.SwitchLanguage += ChangeLabel;
        ChangeLabel();
    }
    private void ChangeLabel()
    {
        _levelsLabel.text = _language.MenuLevelsLabel;
        _arenaLabel.text = _language.MenuArenaLabel;
        _sensitivityLabel.text = _language.MenuSensitivityLabel;
        _musicVolumeLabel.text = _language.MenuMusicVolumeLabel;
        _effectVolumeLabel.text = _language.MenuEffectVolumeLabel;
        _bestScoreLabel.text = _language.BestScoreLabel + PlayerPrefs.GetInt("ArenaBestScore").ToString();
    }
    private void OnDisable()
    {
        _language.SwitchLanguage -= ChangeLabel;
    }
}
