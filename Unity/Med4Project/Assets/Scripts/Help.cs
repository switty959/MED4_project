using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Help : MonoBehaviour
{

    public Canvas canvas;
    public GameObject player;
    public GameObject panel;
    public Canvas exitCanvas;
    void Start()
    {

        Invoke("ShowInstructions", 2);

    }

    public void ShowInstructions()
    {
        canvas.gameObject.SetActive(true);
        exitCanvas.gameObject.SetActive(false);
        FreezePlayer();
    }

    public void CloseInstructions()
    {
        canvas.gameObject.SetActive(false);
        exitCanvas.gameObject.SetActive(true);
        UnfreezePlayer();
    }

    public void End()
    {
        panel.SetActive(true);
        FreezePlayer();
    }

    private void FreezePlayer()
    {
        player.GetComponent<SimpleCharacterControlFree>().enabled = false;
        player.GetComponent<Animator>().enabled = false;
        player.GetComponent<AudioSource>().enabled = false;
        player.GetComponent<Rigidbody>().isKinematic = true;
    }

    private void UnfreezePlayer()
    {
        player.GetComponent<SimpleCharacterControlFree>().enabled = true;
        player.GetComponent<Animator>().enabled = true;
        player.GetComponent<AudioSource>().enabled = true;
        player.GetComponent<Rigidbody>().isKinematic = false;
    }

    public void EndGame()
    {
        Application.Quit();
    }
}
