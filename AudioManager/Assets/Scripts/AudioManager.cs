using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField]
    Audio[] soundEffects;

    // Awake is always called before any Start functions
    void Awake()
    {

    }

    // Use this for initialization
    void Start()
    {
        for (int i = 0; i < soundEffects.Length; i++)
        {
            GameObject _go = new GameObject("Sound_" + i + "_" + soundEffects[i].name);
            _go.transform.SetParent(gameObject.transform);
            soundEffects[i].SetSource(_go.AddComponent<AudioSource>());
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
}
