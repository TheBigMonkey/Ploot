using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WateringSound : MonoBehaviour {
    AudioSource source;

    public void start() {
        source = GetComponent<AudioSource>();
    }

    public void WateringSoundPlay() {
        source.Play();
    }
}