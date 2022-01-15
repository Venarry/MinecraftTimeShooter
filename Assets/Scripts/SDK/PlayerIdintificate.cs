using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerIdintificate : MonoBehaviour
{
    private YandexSDK _sdk;

    [SerializeField] private Text _arenaScoreLabel;
    private LanguageSwitcher _language;
    private int _arenaBestScore;

    private void Start()
    {
        _sdk = YandexSDK.Instance;
        _language = FindObjectOfType<LanguageSwitcher>();

        _arenaBestScore = PlayerPrefs.GetInt("ArenaBestScore");

        LableRefresh();
       
        _sdk.ShowCommonAdvertisment();       
        _sdk.AuthSuccess += _sdk.GettingData;
        _sdk.DataGet += SettingData;
        _sdk.LanguageGet += SwitchLanguage;
        _sdk.Authenticate();       
    }

    public void SwitchLanguage()
    {
        if (!PlayerPrefs.HasKey("Language"))
        {
            PlayerPrefs.SetInt("Auth", 1);
            if (_sdk.UserLanguage == "com")
            {             
                _language.SwitchToEnglish();
            }
            else _language.SwitchToRussian();
        }
    }

    private void SettingData()
    {
        _arenaBestScore = _sdk.GetUserGameData.ArenaScore;
        int _currentLevel = _sdk.GetUserGameData.CurrentLevel;
        Debug.Log(_currentLevel);
        Debug.Log(_sdk.GetUserGameData.CurrentLevel);
        LableRefresh();

        PlayerPrefs.SetInt("ArenaBestScore", _arenaBestScore);
        PlayerPrefs.SetInt("CurrentLevel", _currentLevel);
    }
    private void LableRefresh()
    {
        _arenaScoreLabel.text = _language.BestScoreLabel + _arenaBestScore.ToString();
    }
    private void OnDisable()
    {
        _sdk.AuthSuccess -= _sdk.GettingData;
        _sdk.DataGet -= SettingData;
        _sdk.LanguageGet -= SwitchLanguage;
    }
}
