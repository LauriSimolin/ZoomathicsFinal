using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXPlaying : MonoBehaviour {

    public AudioSource Spawnpoint;

    public void PlaySpawnpoint()
    {
        Spawnpoint.Play();
    }
}
