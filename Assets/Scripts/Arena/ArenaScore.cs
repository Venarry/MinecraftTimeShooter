using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ArenaScore : MonoBehaviour
{
    [SerializeField] private Text _scoreLabel;
    [SerializeField] private Text _gettingScoreEffect;
    private int _score;
    private int _bestScore;
    private PlayerDataSave _dataSave;
    private LanguageSwitcher _language;
    private YandexSDK _sdk;

    private void Start()
    {
        _dataSave = FindObjectOfType<PlayerDataSave>();
        _language = FindObjectOfType<LanguageSwitcher>();
        _sdk = YandexSDK.Instance;
        _scoreLabel.text = _language.ScoreLabel + 0.ToString();
        _bestScore = PlayerPrefs.GetInt("ArenaBestScore");
    }

    public void GetScore(int recivedScore)
    {
        _score += recivedScore;
        _scoreLabel.text = _language.ScoreLabel + _score.ToString();

        _gettingScoreEffect.gameObject.SetActive(true);
        _gettingScoreEffect.text = "+" + recivedScore.ToString();

        if (_score > _bestScore)
        {
            PlayerPrefs.SetInt("ArenaBestScore", _score);
            _dataSave.DataSave();
            _sdk.setLeaderScore(_score);
        }
    }
}
