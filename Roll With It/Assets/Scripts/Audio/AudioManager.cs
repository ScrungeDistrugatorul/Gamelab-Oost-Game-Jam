using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private AudioMixer mixer;

    public void SetMasterVolume(float pVolume)
    {
        mixer.SetFloat("MasterVolume", Mathf.Log10(pVolume) * 20f);
    }

    public void SetMusicVolume(float pVolume)
    {
        mixer.SetFloat("MusicVolume", Mathf.Log10(pVolume) * 20f);

    }

    public void SetSFXVolume(float pVolume)
    {
        mixer.SetFloat("SFXVolume", Mathf.Log10(pVolume) * 20f);
    }
}
