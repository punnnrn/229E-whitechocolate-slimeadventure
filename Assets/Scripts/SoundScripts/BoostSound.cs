using UnityEngine;

public class BoostSound : MonoBehaviour
{
    [Header("Audio")]
    public AudioClip boostSound;
    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            audioSource.PlayOneShot(boostSound);
        }
    }
}
