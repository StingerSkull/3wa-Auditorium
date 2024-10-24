using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class MixerVolume : MonoBehaviour
{
    public AudioMixer myMixer;
    public string exposedName;

    public void SetVolume(float volume)
    {
        float decibel = Mathf.Log10(volume) * 20f;
        myMixer.SetFloat(exposedName, decibel);
    }
}
