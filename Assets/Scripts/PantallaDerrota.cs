using UnityEngine;
using UnityEngine.SceneManagement;

public class PantallaDerrota: MonoBehaviour
{
    void Start()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;

        Time.timeScale = 1f;
    }
    public void VolverMenu()
    {
        SceneManager.LoadScene("MenuInicial");
    }
}