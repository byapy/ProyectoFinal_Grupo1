using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class ControlSettingMenu : MonoBehaviour
{
    public AudioMixer audioMixerAmbiente;
    public AudioMixer audioMixerSFX;
    public void SetVolume(float volume)
    {
        audioMixerAmbiente.SetFloat("ambiente",volume);
    }

    public void SetVolumeSFX(float volumenSFX)
    {
        audioMixerSFX.SetFloat("volumeSfx", volumenSFX);
        Debug.Log("Volumen SFX ajustado a: " + volumenSFX);
    }

    public void SetQuality(int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
    }

    public void FullScreenSet(bool isFullScreen)
    {
        Screen.fullScreen = isFullScreen;
    }
}
