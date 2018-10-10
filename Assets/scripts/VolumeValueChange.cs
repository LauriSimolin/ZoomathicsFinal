﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VolumeValueChange : MonoBehaviour {
    private AudioSource audioSrc;
    private float musicVolume = 1f;
	// Use this for initialization
	void Start () {
        audioSrc = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
        audioSrc.volume = musicVolume;
	}
    public void SetVolume1(float vol)
    {
        musicVolume = vol;
    }
}
