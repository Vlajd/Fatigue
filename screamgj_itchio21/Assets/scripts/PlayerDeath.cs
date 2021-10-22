using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeath : MonoBehaviour
{
    public AudioSource[] audioDeath = new AudioSource[1];


    public void playerDeath () {
        if (audioDeath[0].isPlaying == false) {
            audioDeath[0].Play();
        }
    }
}
