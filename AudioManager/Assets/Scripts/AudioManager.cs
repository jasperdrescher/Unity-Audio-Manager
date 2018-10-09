using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    [Header("Preferences")]
    [SerializeField]
    private float volumeThreshold = -80.0f;

    [Header("References")]
    [SerializeField]
    private AudioMixer mixer;

    [SerializeField]
    private Audio[] music;

    [SerializeField]
    private Audio[] soundEffects;

    public static AudioManager instance;

    // Awake is always called before any Start functions
    void Awake()
    {
        instance = this;

        for (int i = 0; i < music.Length; i++)
        {
            GameObject audioObject = new GameObject("Audio_" + i + "_" + soundEffects[i].name);
            audioObject.transform.SetParent(gameObject.transform);
            audioObject.AddComponent<AudioSource>();
            audioObject.GetComponent<AudioSource>().outputAudioMixerGroup = mixer.FindMatchingGroups("Music")[0];
            soundEffects[i].SetSource(audioObject.GetComponent<AudioSource>());
        }

        for (int i = 0; i < soundEffects.Length; i++)
        {
            GameObject audioObject = new GameObject("Audio_" + i + "_" + soundEffects[i].name);
            audioObject.transform.SetParent(gameObject.transform);
            audioObject.AddComponent<AudioSource>();
            audioObject.GetComponent<AudioSource>().outputAudioMixerGroup = mixer.FindMatchingGroups("SFX")[0];
            soundEffects[i].SetSource(audioObject.GetComponent<AudioSource>());
        }
    }

    // Use this for initialization
    void Start()
    {

    }

    public void PlayMusic(string name)
    {
        for (int i = 0; i < music.Length; i++)
        {
            if (music[i].name == name)
            {
                music[i].Play();
                return;
            }
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
    public void SetMasterVolume(float sliderValue)
    {
        if (sliderValue <= 0)
        {
            mixer.SetFloat("masterVolume", volumeThreshold);
        }
        else
        {
            // Translate unit range to logarithmic value. 
            float value = 20f * Mathf.Log10(sliderValue);
            mixer.SetFloat("masterVolume", value);
        }
    }

    /// <summary>
    /// Set the music volume of the audio mixer.
    /// </summary>
    public void SetMusicVolume(float sliderValue)
    {
        if (sliderValue <= 0)
        {
            mixer.SetFloat("musicVolume", volumeThreshold);
        }
        else
        {
            // Translate unit range to logarithmic value. 
            float value = 20f * Mathf.Log10(sliderValue);
            mixer.SetFloat("musicVolume", value);
        }
    }

    /// <summary>
    /// Set the SFX volume of the audio mixer.
    /// </summary>
    public void SetSoundEffectsVolume(float sliderValue)
    {
        if (sliderValue <= 0)
        {
            mixer.SetFloat("effectsVolume", volumeThreshold);
        }
        else
        {
            // Translate unit range to logarithmic value. 
            float value = 20f * Mathf.Log10(sliderValue);
            mixer.SetFloat("effectsVolume", value);
        }
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
