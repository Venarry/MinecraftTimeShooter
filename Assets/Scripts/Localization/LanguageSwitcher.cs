using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LanguageSwitcher : MonoBehaviour
{
    public string MenuLevelsLabel;
    public string MenuArenaLabel;

    public string WinLabel;
    public string LoseLabel;

    public string ScoreLabel;
    public string BestScoreLabel;

    public delegate void LanguageSwitch();
    public event LanguageSwitch SwitchLanguage;

    private void Start()
    {
        if (PlayerPrefs.HasKey("Language"))
        {
            switch (PlayerPrefs.GetInt("Language"))
            {
                case 1:
                    SwitchToRussian();
                    break;
                case 2:
                    SwitchToEnglish();
                    break;
            }
        }
        else
            SwitchToRussian();
    }

    public void SwitchToRussian()
    {
        MenuLevelsLabel = "Уровни";
        MenuArenaLabel = "Арена";
        WinLabel = "Победа";
        LoseLabel = "Поражение";
        ScoreLabel = "Очки: ";
        BestScoreLabel = "Лучший результат: ";

        if (PlayerPrefs.HasKey("Auth"))
            PlayerPrefs.SetInt("Language", 1);
        
        SwitchLanguage?.Invoke();
    }

    public void SwitchToEnglish()
    {
        MenuLevelsLabel = "Levels";
        MenuArenaLabel = "Arena";
        WinLabel = "Victory";
        LoseLabel = "Defeat";
        ScoreLabel = "Score: ";
        BestScoreLabel = "Best Score: ";

        if (PlayerPrefs.HasKey("Auth"))
            PlayerPrefs.SetInt("Language", 2);
        
        SwitchLanguage?.Invoke();
    }
}
