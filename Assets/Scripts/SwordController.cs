using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordController : MonoBehaviour
{
    private SliceObject sliceObject;
    public AudioClip normSwingSound;
    private AudioSource audioPlayer;

    // public Transform bladeEdgeTransform;
    // public ParticleSystem slashEffect;

    public float swingThreshold = 1.0f;
    public float swingTerm = 0.5f;
    private float lastSwingTime;

    private void Awake() {
        audioPlayer = GetComponent<AudioSource>();
        sliceObject = GetComponent<SliceObject>();
    }
}
