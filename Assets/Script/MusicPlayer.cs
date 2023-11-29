using UnityEngine;
using UnityEngine.Audio;

public class MusicPlayer : MonoBehaviour
{
    public AudioClip musicClip; // Assign your music clip in the Unity inspector
    public AudioMixerGroup audioMixerGroup; // Assign an Audio Mixer Group for volume control if needed

    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = musicClip;
        audioSource.outputAudioMixerGroup = audioMixerGroup; // Assign the Audio Mixer Group

        // Start playing the music and set it to loop
        audioSource.loop = true;
        audioSource.Play();
    }
}
