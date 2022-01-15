using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMusic : MonoBehaviour
{
    [SerializeField] private AudioClip[] _audios;
    [SerializeField] private AudioSource _audioSource;

    private void Start()
    {
        _audioSource.GetComponent<AudioSource>();

        _audioSource.PlayOneShot(_audios[Random.Range(0, _audios.Length)], _audioSource.volume);
        //_audioSource.clip = _audios[Random.Range(0, _audios.Length)];
    }
}
