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
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);

        for (int i = 0; i < music.Length; i++)
        {
            GameObject audioObject = new GameObject("Music_" + i + "_" + music[i].audioName);
            audioObject.AddComponent<AudioSource>();
            audioObject.GetComponent<AudioSource>().outputAudioMixerGroup = mixer.FindMatchingGroups("Music")[0];
            audioObject.GetComponent<AudioSource>().loop = music[i].audioLoop;
            audioObject.GetComponent<AudioSource>().volume = music[i].audioVolume;
            audioObject.GetComponent<AudioSource>().clip = music[i].audioClip;
            music[i].audioSource = audioObject.GetComponent<AudioSource>();
        }

        for (int i = 0; i < soundEffects.Length; i++)
        {
            GameObject audioObject = new GameObject("Effects_" + i + "_" + soundEffects[i].audioName);
            audioObject.AddComponent<AudioSource>();
            audioObject.GetComponent<AudioSource>().outputAudioMixerGroup = mixer.FindMatchingGroups("SFX")[0];
            audioObject.GetComponent<AudioSource>().loop = soundEffects[i].audioLoop;
            audioObject.GetComponent<AudioSource>().volume = soundEffects[i].audioVolume;
            audioObject.GetComponent<AudioSource>().clip = soundEffects[i].audioClip;
            soundEffects[i].audioSource = audioObject.GetComponent<AudioSource>();
        }
    }

    // Use this for initialization
    void Start()
    {

    }

    /// <summary>
    /// Play music from the array.
    /// </summary>
    public void PlayMusic(string name)
    {
        for (int i = 0; i < music.Length; i++)
        {
            if (music[i].audioName == name)
            {
                music[i].Play();
                return;
            }
        }
    }

    /// <summary>
    /// Play a sound-effect from the array.
    /// </summary>
    public void PlaySound(string name)
    {
        for (int i = 0; i < soundEffects.Length; i++)
        {
            if (soundEffects[i].audioName == name)
            {
                soundEffects[i].Play();
                return;
            }
        }

        Debug.Log("AudioManager: " + name + " not found in list.");
    }

    /// <summary>
    /// Pause music from the array.
    /// </summary>
    public void PauseMusic(string name)
    {
        for (int i = 0; i < music.Length; i++)
        {
            if (music[i].audioName == name)
            {
                music[i].Pause();
                return;
            }
        }

        Debug.Log("AudioManager: " + name + " not found in list.");
    }

    /// <summary>
    /// Pause a sound from the array.
    /// </summary>
    public void PauseSound(string name)
    {
        for (int i = 0; i < soundEffects.Length; i++)
        {
            if (soundEffects[i].audioName == name)
            {
                soundEffects[i].Pause();
                return;
            }
        }

        Debug.Log("AudioManager: " + name + " not found in list.");
    }

    /// <summary>
    /// Resume music from the array.
    /// </summary>
    public void ResumeMusic(string name)
    {
        for (int i = 0; i < music.Length; i++)
        {
            if (music[i].audioName == name)
            {
                music[i].Resume();
                return;
            }
        }

        Debug.Log("AudioManager: " + name + " not found in list.");
    }

    /// <summary>
    /// Resume a sound-effect from the array.
    /// </summary>
    public void ResumeSound(string name)
    {
        for (int i = 0; i < soundEffects.Length; i++)
        {
            if (soundEffects[i].audioName == name)
            {
                soundEffects[i].Resume();
                return;
            }
        }

        Debug.Log("AudioManager: " + name + " not found in list.");
    }

    /// <summary>
    /// Stop music from the array.
    /// </summary>
    public void StopMusic(string name)
    {
        for (int i = 0; i < music.Length; i++)
        {
            if (music[i].audioName == name)
            {
                music[i].Stop();
                return;
            }
        }

        Debug.Log("AudioManager: " + name + " not found in list.");
    }

    /// <summary>
    /// Stop a sound-effect from the array.
    /// </summary>
    public void StopSound(string name)
    {
        for (int i = 0; i < soundEffects.Length; i++)
        {
            if (soundEffects[i].audioName == name)
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
