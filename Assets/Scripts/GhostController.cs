using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GhostController : MonoBehaviour
{
    [SerializeField] private Transform player;

    [SerializeField] private AudioSource audioSource;

    [SerializeField] private AudioClip behindYouClip;

    [SerializeField] private GameObject[] ghostParts;

    [SerializeField] private Animator animator;

    [SerializeField] private float speed = 3.5f;

    private bool chasing = false;

    private void Start()
    {
        foreach (GameObject part in ghostParts)
        {
            part.SetActive(false);
        }
    }

    private void Update()
    {
        if (chasing)
        {
            transform.position =
                Vector3.MoveTowards(
                    transform.position,
                    player.position,
                    speed * Time.deltaTime);

            Vector3 lookPos = player.position;

            lookPos.y = transform.position.y;

            transform.LookAt(lookPos);
        }
    }

    public void SpawnGhost()
    {
        StartCoroutine(SpawnSequence());
    }

    IEnumerator SpawnSequence()
    {
        yield return new WaitForSeconds(10f);

        audioSource.PlayOneShot(behindYouClip);

        Vector3 spawnPos =
            player.position
            - player.forward * 10f
            + player.right * Random.Range(-4f, 4f);

        RaycastHit hit;

        if (Physics.Raycast(
            spawnPos + Vector3.up * 20f,
            Vector3.down,
            out hit,
            50f))
        {
            spawnPos.y = hit.point.y;
        }

        transform.position = spawnPos;

        Vector3 lookPos = player.position;

        lookPos.y = transform.position.y;

        transform.LookAt(lookPos);

        foreach (GameObject part in ghostParts)
        {
            part.SetActive(true);
        }

        animator.Play("A_Pose");

        yield return new WaitForSeconds(8f);

        animator.Play("Chasing");

        chasing = true;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            SceneManager.LoadScene("PantallaDerrota");
        }
    }
}