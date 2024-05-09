using System.Collections;
using UnityEngine;

public class CollisionSounds : MonoBehaviour
{
    public AudioClip[] collisionSounds;
    private AudioSource audioSource;

    private bool isReady = false;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        StartCoroutine(DelaySoundActivation(0.5f));
    }

    IEnumerator DelaySoundActivation(float delay)
    {
        yield return new WaitForSeconds(delay);
        isReady = true;
    }

    void OnCollisionEnter(Collision collision)
    {
        if (isReady && (collision.gameObject.CompareTag("MapObject") || collision.gameObject.CompareTag("MovableObject")))
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
