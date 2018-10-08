using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    [Header("References")]
    [SerializeField]
    private AudioMixer mixer;

    [SerializeField]
    private Audio[] soundEffects;

    // Awake is always called before any Start functions
    void Awake()
    {

    }

    // Use this for initialization
    void Start()
    {
        for (int i = 0; i < soundEffects.Length; i++)
        {
            GameObject gameObject = new GameObject("Audio_" + i + "_" + soundEffects[i].name);
            gameObject.transform.SetParent(gameObject.transform);
            gameObject.AddComponent<AudioSource>();
            gameObject.GetComponent<AudioSource>().outputAudioMixerGroup = mixer.outputAudioMixerGroup;
            soundEffects[i].SetSource(gameObject.GetComponent<AudioSource>());
        }
    }

    /// <summary>
    /// Play a sound-effect.
    /// </summary>
    public void PlaySound(string name)
    {
        for (int i = 0; i < soundEffects.Length; i++)
        {
            if (soundEffects[i].name == name)
            {
                soundEffects[i].Play();
                return;
            }
        }

        Debug.Log("AudioManager: " + name + " not found in list.");
    }

    /// <summary>
    /// Pause a sound.
    /// </summary>
    public void PauseSound(string _name)
    {
        for (int i = 0; i < soundEffects.Length; i++)
        {
            if (soundEffects[i].name == _name)
            {
                soundEffects[i].Pause();
                return;
            }
        }

        Debug.Log("AudioManager: " + name + " not found in list.");
    }

    /// <summary>
    /// Resume a sound-effect.
    /// </summary>
    public void ResumeSound(string _name)
    {
        for (int i = 0; i < soundEffects.Length; i++)
        {
            if (soundEffects[i].name == _name)
            {
                soundEffects[i].Resume();
                return;
            }
        }

        Debug.Log("AudioManager: " + name + " not found in list.");
    }

    /// <summary>
    /// Stop a sound-effect.
    /// </summary>
    public void StopSound(string _name)
    {
        for (int i = 0; i < soundEffects.Length; i++)
        {
            if (soundEffects[i].name == _name)
            {
                soundEffects[i].Stop();
                return;
            }
        }

        Debug.Log("AudioManager: " + name + " not found in list.");
    }

    /// <summary>
    /// Set the master volume of the audio mixer.
    /// </summary>
    public void SetMasterVolume(float value)
    {
        mixer.SetFloat("masterVolume", value);
    }

    /// <summary>
    /// Set the music volume of the audio mixer.
    /// </summary>
    public void SetMusicVolume(float value)
    {
        mixer.SetFloat("musicVolume", value);
    }

    /// <summary>
    /// Set the SFX volume of the audio mixer.
    /// </summary>
    public void SetSoundEffectsVolume(float value)
    {
        mixer.SetFloat("effectsVolume", value);
    }

    /// <summary>
    /// Clear the master volume of the audio mixer. This is useful for audio snapshots.
    /// </summary>
    public void ClearMasterVolume()
    {
        mixer.ClearFloat("masterVolume");
    }

    /// <summary>
    /// Clear the music volume of the audio mixer. This is useful for audio snapshots.
    /// </summary>
    public void ClearMusicVolume()
    {
        mixer.ClearFloat("musicVolume");
    }

    /// <summary>
    /// Clear the SFX volume of the audio mixer. This is useful for audio snapshots.
    /// </summary>
    public void ClearSoundEffectsVolume()
    {
        mixer.ClearFloat("effectsVolume");
    }
}
