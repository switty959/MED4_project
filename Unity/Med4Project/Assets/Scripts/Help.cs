using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Help : MonoBehaviour
{

    public GameObject tutorial;
    public GameObject player;
    public GameObject EndScreen;
    public GameObject exitHelpButtons;
    void Start()
    {

        Invoke("ShowInstructions", 2);

    }

    public void ShowInstructions()
    {
        tutorial.SetActive(true);
        exitHelpButtons.SetActive(false);
        FreezePlayer();
    }

    public void CloseInstructions()
    {
        tutorial.SetActive(false);
        exitHelpButtons.SetActive(true);
        UnfreezePlayer();
    }

    public void End()
    {
        exitHelpButtons.SetActive(false);
        EndScreen.SetActive(true);
        FreezePlayer();
    }

    private void FreezePlayer()
    {
        player.GetComponent<SimpleCharacterControlFree>().enabled = false;
        player.GetComponent<Animator>().enabled = false;
        player.GetComponent<Rigidbody>().isKinematic = true;
    }

    private void UnfreezePlayer()
    {
        player.GetComponent<SimpleCharacterControlFree>().enabled = true;
        player.GetComponent<Animator>().enabled = true;
        player.GetComponent<Rigidbody>().isKinematic = false;
    }

    public void EndGame()
    {
        Application.Quit();
    }
}
