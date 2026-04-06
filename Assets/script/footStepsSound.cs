using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootstepsSound : MonoBehaviour
{
    private AudioSource audioSource;

    [Header("FootSteps Sources")]
    [SerializeField] private AudioClip[] footstepsSound;

    private void Awake()
    {
        // Getting the AudioSource component
        audioSource = GetComponent<AudioSource>();
    }

    // Method to get a random footstep sound
    private AudioClip GetRandomFootStep()
    {
        // Returning a random AudioClip from the footstepsSound array
        return footstepsSound[UnityEngine.Random.Range(0, footstepsSound.Length)];
    }

    // Method to play the footstep sound
    private void step()
    {
        // Get a random footstep sound and play it
        AudioClip clip = GetRandomFootStep();
        audioSource.PlayOneShot(clip);
    }
}
   
