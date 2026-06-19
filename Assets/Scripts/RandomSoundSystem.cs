using UnityEngine;
using System.Collections;

public class RandomSoundSystem : MonoBehaviour
{
    [Header("Sounds")]
    [SerializeField] private AudioClip[] sounds;

    [Header("References")]
    [SerializeField] private AudioSource audioSource;

    [SerializeField] private GameObject flashlight;

    [Header("Timing")]
    [SerializeField] private float firstDelay = 50f;

    [SerializeField] private float minDelay = 30f;

    [SerializeField] private float maxDelay = 40f;

    [SerializeField] private Transform player;

    private void Start()
    {
        StartCoroutine(SoundLoop());
    }

    IEnumerator SoundLoop()
    {
        yield return new WaitForSeconds(firstDelay);

        while (true)
        {
            PlayRandomSound();

            yield return new WaitForSeconds(
                Random.Range(minDelay, maxDelay)
            );
        }
    }

    void PlayRandomSound()
    {
        if (sounds.Length == 0)
            return;

        int randomIndex;

        if (Random.Range(0, 100) < 5)
        {
            randomIndex = 4;
        }
        else
        {
            randomIndex = Random.Range(0, 4);
        }

        float distance =
            randomIndex == 4 ?
            Random.Range(12f, 18f)
            :
            Random.Range(6f, 12f);

        Vector3 randomPos =
            player.position
            + Random.onUnitSphere
            * distance;

        randomPos.y =
            player.position.y;

        audioSource.transform.position =
            randomPos;

        flashlight.SetActive(false);

        audioSource.clip =
            sounds[randomIndex];

        audioSource.Play();
    }
}