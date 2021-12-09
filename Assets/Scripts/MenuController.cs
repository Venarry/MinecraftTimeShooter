using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    private YandexSDK _sdk;
    private Player _player;

    private void Start()
    {
        _sdk = YandexSDK.Instance;
        _player = FindObjectOfType<Player>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R) && !_player.GameOver)
        {
            RestartLevel();
        }
        if (Input.GetKeyDown(KeyCode.T) && !_player.GameOver)
        {
            NextLevel();
        }
        if (Input.GetKeyDown(KeyCode.Escape) && SceneManager.GetActiveScene().name != "Menu")
        {
            MainMenu();
            _sdk.ShowCommonAdvertisment();
        }
    }

    public void RestartLevel()
    {
        string _currentScene = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(_currentScene);

        _sdk.ShowCommonAdvertisment();
    }
    public void NextLevel()
    {
        int i = SceneManager.GetActiveScene().buildIndex + 1;
        if (i >= SceneManager.sceneCountInBuildSettings - 1) //  минус число - кол-во сцен после уровней
            i = 1;

        PlayerPrefs.SetInt("CurrentLevel", i);
        SceneManager.LoadScene(i);

        _sdk.ShowCommonAdvertisment();
    }
    public void StartGameLevels()
    {
        if (PlayerPrefs.HasKey("CurrentLevel"))
        {
            SceneManager.LoadScene(PlayerPrefs.GetInt("CurrentLevel"));
        }
        else SceneManager.LoadScene(1);
    }
    public void StartGameArena()
    {
        SceneManager.LoadScene("Arena");
    }
    public void MainMenu()
    {
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;
        SceneManager.LoadScene("Menu");
    }
}
