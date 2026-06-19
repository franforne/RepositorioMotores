using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPausa : MonoBehaviour
{
    public GameObject PausaPanel;

    private bool paused = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (paused)
                Continuar();
            else
                Pause();
        }
    }

    void Pause()
    {
        paused = true;

        PausaPanel.SetActive(true);

        Time.timeScale = 0f;

        AudioListener.pause = true;

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void Continuar()
    {
        paused = false;

        PausaPanel.SetActive(false);

        Time.timeScale = 1f;

        AudioListener.pause = false;

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public void VolverMenu()
    {
        Time.timeScale = 1f;

        AudioListener.pause = false;

        SceneManager.LoadScene("MenuInicial");
    }

    public static bool IsPaused()
    {
        return Time.timeScale == 0f;
    }
}