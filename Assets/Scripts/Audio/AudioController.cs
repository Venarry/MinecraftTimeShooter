using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class AudioController : MonoBehaviour
{
    [SerializeField] private AudioMixerGroup _mixer; 
    [SerializeField] private Slider _musicSlider;
    [SerializeField] private Slider _effectSlider;

    private void Start()
    {
        float savedVolume;
        if (PlayerPrefs.HasKey("MusicVolume"))
        {
            savedVolume = PlayerPrefs.GetFloat("MusicVolume");
        }
        else savedVolume = 1f;

        MusicController(savedVolume);
        _musicSlider.value = savedVolume;

        if (PlayerPrefs.HasKey("EffectVolume"))
        {
            savedVolume = PlayerPrefs.GetFloat("EffectVolume");
        }
        else savedVolume = 1f;

        EffectController(savedVolume);
        _effectSlider.value = savedVolume;
    }
    public void MusicController(float volume)
    {
        _mixer.audioMixer.SetFloat("Music", Mathf.Lerp(-80,0, volume));
        PlayerPrefs.SetFloat("MusicVolume", volume);
    }
    public void EffectController(float volume)
    {
        _mixer.audioMixer.SetFloat("Effect", Mathf.Lerp(-80, 0, volume));
        PlayerPrefs.SetFloat("EffectVolume", volume);
    }
}
