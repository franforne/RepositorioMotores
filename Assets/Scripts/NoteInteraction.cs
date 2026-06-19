
using UnityEngine;

public class NoteInteraction : MonoBehaviour
{
    [SerializeField] private GameObject interactText;
    [SerializeField] private GameObject noteUI;

    private bool playerNear;
    private bool noteOpen;

    private void Start()
    {
        playerNear = false;
        noteOpen = false;

        interactText.SetActive(false);
        noteUI.SetActive(false);
    }

    private void Update()
    {
        if (playerNear && Input.GetKeyDown(KeyCode.E))
        {
            noteOpen = !noteOpen;

            noteUI.SetActive(noteOpen);

            // Mostrar texto solo cuando NO está abierta la nota
            interactText.SetActive(playerNear && !noteOpen);

            Time.timeScale = noteOpen ? 0f : 1f;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerNear = true;

            if (!noteOpen)
                interactText.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerNear = false;
            noteOpen = false;

            interactText.SetActive(false);
            noteUI.SetActive(false);

            Time.timeScale = 1f;
        }
    }
}