using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;



public class YandexSDK : MonoBehaviour
{
    // Создание SINGLETON
    private static YandexSDK _instance;
    public static YandexSDK Instance
    {
        get
        {
            if (_instance == null)
                _instance = GameObject.FindObjectOfType<YandexSDK>();
            
            return _instance;
        }
    }
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
       
    }
    
    public UserGameData UGD;
    private UserData UD;

    public UserGameData GetUserGameData => UGD;

    public UserData GetUserData => UD;
    
    
    [DllImport("__Internal")]
    private static extern void Auth();    // Авторизация - внешняя функция для связи с плагином
    [DllImport("__Internal")]
    private static extern void ShowCommonADV();    // Показ обычной рекламы - внешняя функция для связи с плагином
    [DllImport("__Internal")]
    private static extern void GetData();    // Получение данных - внешняя функция для связи с плагином
    [DllImport("__Internal")]
    private static extern void SetData(string data);    // Отправка данных - внешняя функция для связи с плагином
    [DllImport("__Internal")]
    private static extern void ShowRewardADV();    // Показ рекламы с наградой - внешняя функция для связи с плагином
    [DllImport("__Internal")]
    private static extern void GetLeaderBoardEntries();
    [DllImport("__Internal")]
    private static extern void GetLanguage(string _language);
    [DllImport("__Internal")]
    private static extern void SetLeaderBoard(int score);  
    
    
    public event Action AuthSuccess;    //События
    public event Action DataGet;    //События
    public event Action RewardGet;  //События
    public event Action LanguageGet;  //События
    public event Action<string> LeaderBoardReady;

    public string UserLanguage;
    public void Language(string _language)
    {
        UserLanguage = _language;
        LanguageGet?.Invoke();
        Debug.Log("LanguageIsGettingYSDK");
    }
    public void Authenticate()    //    Авторизация
    {
        Auth();
    }

    public void GettingData()    // Получение данных
    {
        GetData();
    }

    public void SettingData(string data)    // Сохранение данных
    {
        SetData(data);
    }

    public void getLeaderEntries()
    {
        GetLeaderBoardEntries();
    }

    public void setLeaderScore(int score)
    {
        SetLeaderBoard(score);
    }

    public void BoardEntriesReady(string _data)
    {
        LeaderBoardReady?.Invoke(_data);
    }

    public void ShowCommonAdvertisment()    // Показ обычной рекламы
    {
        ShowCommonADV();
    }

    public void ShowRewardAdvertisment()    // Показ рекламы с наградой
    {
        ShowRewardADV();
    }

    
    public void AuthenticateSuccess(string data)    // Авторизация успешно пройдена
    {
        UD.Name = data;
        AuthSuccess?.Invoke();
    }
    
    public void DataGetting(string data) // Данные получены
    {
        UserDataSaving UDS = new UserDataSaving();
        UDS = JsonUtility.FromJson<UserDataSaving>(data);
        UGD = JsonUtility.FromJson<UserGameData>(UDS.data);
        //UGD = JsonUtility.FromJson<UserGameData>(data);
        DataGet?.Invoke();
    }
    
    public void RewardGetting() // Реклама просмотрена
    {
        RewardGet?.Invoke();
    }

}

[Serializable]
public class UserData
{
    public string Name;
    public string image;
    
}

[Serializable]
public class UserGameData
{
    public int ArenaScore = 0;
    public int CurrentLevel = 0;
    public UserGameData(int _arenaScore, int _currentLevel)
    {
        ArenaScore = _arenaScore;
        CurrentLevel = _currentLevel;
    }
}
[Serializable]
public class UserDataSaving
{
    public string data;
}

