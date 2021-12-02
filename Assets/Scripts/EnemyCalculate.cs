using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCalculate : MonoBehaviour
{
    private int _enemysCount;
    private Player _player;

    private void Start()
    {
        _player = FindObjectOfType<Player>();
        ChangeEnemyCount();
    }

    public IEnumerator ChangeEnemyCount()
    {
        yield return new WaitForSeconds(0.05f);
        Enemy[] allEnemys = FindObjectsOfType<Enemy>();
        _enemysCount = allEnemys.Length;

        if(_enemysCount <= 0)
        {
            _player.Win();
        }
    }

}
