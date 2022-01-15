using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LanguageSwitcher : MonoBehaviour
{
    public string MenuLevelsLabel;
    public string MenuArenaLabel;
    public string MenuSensitivityLabel;
    public string MenuMusicVolumeLabel;
    public string MenuEffectVolumeLabel;

    public string WinLabel;
    public string LoseLabel;
    public string FAQ;

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
        MenuLevelsLabel = "������";
        MenuArenaLabel = "�����";
        MenuSensitivityLabel = "����������������";
        MenuMusicVolumeLabel = "��������� ������";
        MenuEffectVolumeLabel = "��������� ������";
        WinLabel = "������";
        LoseLabel = "���������";
        FAQ = "Esc - ����  R-�������������";
        ScoreLabel = "����: ";
        BestScoreLabel = "������ ���������: ";

        if (PlayerPrefs.HasKey("Auth"))
            PlayerPrefs.SetInt("Language", 1);
        
        SwitchLanguage?.Invoke();
    }

    public void SwitchToEnglish()
    {
        MenuLevelsLabel = "Levels";
        MenuArenaLabel = "Arena";
        MenuSensitivityLabel = "Sensitivity";
        MenuMusicVolumeLabel = "Music volume";
        MenuEffectVolumeLabel = "Effect volume";
        WinLabel = "Victory";
        LoseLabel = "Defeat";
        FAQ = "Esc - menu  R-restart";
        ScoreLabel = "Score: ";
        BestScoreLabel = "Best Score: ";

        if (PlayerPrefs.HasKey("Auth"))
            PlayerPrefs.SetInt("Language", 2);
        
        SwitchLanguage?.Invoke();
    }
}
