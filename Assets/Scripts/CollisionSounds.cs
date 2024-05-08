using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionSounds : MonoBehaviour
{
    public AudioClip[] collisionSounds;
    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("MapObject") || collision.gameObject.CompareTag("MovableObject"))
        {
            PlayRandomCollisionSound();
        }
    }

    void PlayRandomCollisionSound()
    {
        if (collisionSounds.Length > 0)
        {
            int randomIndex = Random.Range(0, collisionSounds.Length);
            audioSource.PlayOneShot(collisionSounds[randomIndex]);
        }
    }
}
