using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Help : MonoBehaviour
{

    public Canvas canvas;
    public GameObject player;
    public GameObject panel;
    void Start()
    {
        
        Invoke("ShowInstructions", 2);

    }

    private void ShowInstructions()
    {
        canvas.gameObject.SetActive(true);
        FreezePlayer();
    }

    public void CloseInstructions()
    {
        canvas.gameObject.SetActive(false);
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
    }

    private void UnfreezePlayer()
    {
        player.GetComponent<SimpleCharacterControlFree>().enabled = true;
        player.GetComponent<Animator>().enabled = true;
        player.GetComponent<AudioSource>().enabled = true;
    }

    public void EndGame()
    {
        Application.Quit();
    }
}
