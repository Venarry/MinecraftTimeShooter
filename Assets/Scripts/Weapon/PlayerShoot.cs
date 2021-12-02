using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    [SerializeField] private Transform _shootPoint;
    [SerializeField] private Arrow _bullet;
    [SerializeField] private float _coolDown;
    private Player _player;
    private TimeController _time;
    private float _currentTime;
    private bool _weaponInHand;

    private void Start()
    {
        _player = GetComponent<Player>();
        _time = FindObjectOfType<TimeController>();
        _currentTime = _coolDown;

        if (GetComponentInChildren<Weapon>() != null)
            WeaponStatus(true);
        else 
            WeaponStatus(false);
    }
    private void Update()
    {
        _currentTime += Time.deltaTime;
        if(Input.GetMouseButtonDown(0) && _currentTime >= _coolDown && !_player.GameOver)
        {
            if(_weaponInHand) //(GetComponentInChildren<Weapon>() != null)
            {
                Shoot();
            }
        }
    }

    private void Shoot()
    {
        Instantiate(_bullet, _shootPoint.position, _shootPoint.transform.rotation);
        StartCoroutine(_time.ForcedAcceleration());
        _currentTime = 0;
    }

    public void WeaponStatus(bool have)
    {
        _weaponInHand = have;
    }
}
