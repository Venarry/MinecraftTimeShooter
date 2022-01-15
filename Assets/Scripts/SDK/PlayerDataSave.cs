using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDataSave : MonoBehaviour
{
    private int _arenaScore;
    private YandexSDK _sdk;

    private void Start()
    {
        _sdk = YandexSDK.Instance;
        _sdk.AuthSuccess += Save;
    }

    public void DataSave()
    {
        _sdk.Authenticate();
    }

    private void Save()
    {
        _arenaScore = PlayerPrefs.GetInt("ArenaBestScore");
        int _currentLevel = PlayerPrefs.GetInt("CurrentLevel");
        UserGameData UD = new UserGameData(_arenaScore, _currentLevel);
        _sdk.SettingData(JsonUtility.ToJson(UD));
    }
    private void OnDisable()
    {
        _sdk.AuthSuccess -= Save;
    }
}
