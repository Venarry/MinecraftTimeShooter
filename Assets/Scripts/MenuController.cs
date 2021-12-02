using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    private Player _player;

    private void Start()
    {
        _player = FindObjectOfType<Player>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R) && !_player.GameOver)
        {
            RestartLevel();
        }
    }

    public void RestartLevel()
    {
        string _currentScene = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(_currentScene);
    }
    public void NextLevel()
    {
        int i = SceneManager.GetActiveScene().buildIndex;
        if (i < SceneManager.sceneCountInBuildSettings - 1)
            SceneManager.LoadScene(i+1);
        else SceneManager.LoadScene(0);
    }
}
