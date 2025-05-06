using UnityEngine;

public class WinSound : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip winSound;

    void Start()
    {
        if (audioSource != null && winSound != null)
        {
            audioSource.PlayOneShot(winSound);
        }
    }
}