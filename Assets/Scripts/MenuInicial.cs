using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public GameObject ControlesPanel;

    public void Jugar()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void Controles()
    {
        ControlesPanel.SetActive(true);
    }

    public void VolverMenu()
    {
        ControlesPanel.SetActive(false);
    }

    public void Salir()
    {
        Application.Quit();
    }
}