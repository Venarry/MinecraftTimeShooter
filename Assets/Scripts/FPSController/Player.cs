using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public bool GameOver;

    private MenuController _menu;
    [SerializeField] private GameObject _diePanel;
    [SerializeField] private GameObject _winPanel;

    private void Start()
    {
        _menu = GetComponent<MenuController>();
    }

    public void Lose()
    {
        GameOver = true;
        _diePanel.SetActive(true);
        DestroyArrow();
        StartCoroutine(RestartLevel());
    }

    public void Win()
    {
        GameOver = true;
        _winPanel.SetActive(true);
        DestroyArrow();
        StartCoroutine(NextLevel());
    }
    private void DestroyArrow()
    {
        Arrow[] allArrow = FindObjectsOfType<Arrow>();
        foreach (Arrow currentArrow in allArrow)
        {
            Destroy(currentArrow.gameObject);
        }
    }

    private IEnumerator NextLevel()
    {
        yield return new WaitForSecondsRealtime(1.5f);
        _menu.NextLevel();
    }

    private IEnumerator RestartLevel()
    {
        yield return new WaitForSecondsRealtime(1.5f);
        _menu.RestartLevel();
    }
}
