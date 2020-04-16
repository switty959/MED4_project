using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class buttonController : MonoBehaviour
{
    public GameObject loadingImage;
    public GameObject[] buttonPanels;
   public void startGame(int level)
    {
        loadingImage.SetActive(true);
        SceneManager.LoadScene(level);
    }
    public void exitGame()
    {
        Application.Quit();
    }

    public void instructions()
    {
        buttonPanels[0].SetActive(false); //turning the main menu  off
        buttonPanels[1].SetActive(true); // turning the instruction menu on
    }

    public void mainMenu()
    {
        buttonPanels[1].SetActive(false); //turning the main menu on
        buttonPanels[0].SetActive(true); // turning the instruction menu off
    }
}
