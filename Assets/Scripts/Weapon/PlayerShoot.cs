using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PlayerShoot : MonoBehaviour
{
    [SerializeField] private Transform _shootPoint;
    [SerializeField] private Transform _crossHair;
    [SerializeField] private Arrow _bullet;
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private AudioClip _audioClip;
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
                ShootSound();
            }
        }
    }

    private void Shoot()
    {
        Instantiate(_bullet, _shootPoint.position, _shootPoint.transform.rotation);
        StartCoroutine(_time.ForcedAcceleration());
        CrosshairRotate();
        _currentTime = 0;
    }
    private void ShootSound()
    {
        _audioSource.pitch = Random.Range(0.9f,1.2f);
        _audioSource.PlayOneShot(_audioClip, _audioSource.volume);
    }

    private void CrosshairRotate()
    {
        _crossHair.transform.DORotate(new Vector3(0,0,90), _coolDown, RotateMode.WorldAxisAdd);
    }

    public void WeaponStatus(bool have)
    {
        _weaponInHand = have;
    }
}
