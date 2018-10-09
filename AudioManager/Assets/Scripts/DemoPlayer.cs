using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DemoPlayer : MonoBehaviour
{
    [SerializeField]
    private string musicName;

    // Use this for initialization
    void Start ()
    {
        AudioManager.instance.PlayMusic(musicName);
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}
}
