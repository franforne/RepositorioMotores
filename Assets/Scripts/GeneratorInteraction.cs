using UnityEngine;

public class GeneratorInteraction : MonoBehaviour
{
    [SerializeField] private Light generatorLight;
    [SerializeField] private AudioSource generatorAudio;
    [SerializeField] private GameObject interactText;

    [SerializeField] private float minSoundDistance = 6f;
    [SerializeField] private float maxSoundDistance = 25f;

    private bool playerNear = false;
    private bool isActivated = false;

    private void Start()
    {
        if (generatorLight != null)
            generatorLight.enabled = false;

        if (interactText != null)
            interactText.SetActive(false);

        if (generatorAudio != null)
        {
            generatorAudio.playOnAwake = false;
            generatorAudio.loop = true;

            generatorAudio.spatialBlend = 1f;

            generatorAudio.minDistance = minSoundDistance;
            generatorAudio.maxDistance = maxSoundDistance;
        }
    }

    private void Update()
    {
        if (playerNear && !isActivated && Input.GetKeyDown(KeyCode.E))
        {
            ActivateGenerator();
        }
    }

    void ActivateGenerator()
    {
        isActivated = true;

        generatorLight.enabled = true;

        generatorAudio.Play();

        interactText.SetActive(false);

        GeneratorManager.Instance.ActivateGenerator();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerNear = true;

            if (!isActivated)
                interactText.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerNear = false;

            interactText.SetActive(false);
        }
    }
}


