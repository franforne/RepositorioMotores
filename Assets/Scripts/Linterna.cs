using UnityEngine;

public class Linterna : MonoBehaviour
{
    public GameObject ligthObject;
    public AudioClip ligthSound;

    public AudioSource flashlightSource;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
            LightManager();
    }

    void LightManager()
    {
        flashlightSource.PlayOneShot(ligthSound);

        ligthObject.SetActive(!ligthObject.activeSelf);
    }
}