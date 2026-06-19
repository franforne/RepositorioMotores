using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class GeneratorManager : MonoBehaviour
{
    public static GeneratorManager Instance;

    [SerializeField] private TextMeshProUGUI counterText;

    private int generatorsActivated = 0;

    [SerializeField] private GhostController ghost;

    private void Awake()
    {
        Instance = this;

        counterText.gameObject.SetActive(false);
    }

    public void ActivateGenerator()
    {
        generatorsActivated++;

        if (generatorsActivated == 1)
        {
            counterText.gameObject.SetActive(true);
        }

        counterText.text =
            "Generadores: "
            + generatorsActivated
            + "/3";

        if (generatorsActivated == 2)
        {
            ghost.SpawnGhost();
        }

        if (generatorsActivated >= 3)
        {
            StartCoroutine(LoadPantallaVictoria());
        }
    }

    private IEnumerator LoadPantallaVictoria()
    {
        yield return new WaitForSeconds(1f);

        SceneManager.LoadScene("PantallaVictoria");
    }
}