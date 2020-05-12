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
    public GameObject rageEndScreen;
    public movementScript playerData;
    public databaseSendData database;
    public Text[] UICode;
    int usernameInt;
    public Logic audioCues;
    public AkEvent orb;
    public string condition;
    void Start()
    {
        string username = GameObject.Find("userNameHolder").GetComponent<generateUserName>().username;
        for (int i = 0; i < UICode.Length; i++)
        {
            UICode[i].text = "Code: " + username.ToString();
        }
        
        ShowInstructions();

        usernameInt = int.Parse(username);

        if (usernameInt % 2 == 1)
        {
            audioCues.enabled = false;
            orb.enabled = false;
            condition = "b";
        }

        else
        {
            condition = "a";
        }

        //condition = "Scott";
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
        print(usernameInt);
        if (usernameInt % 2 == 0) // A Test (Audio)
        {
            Application.OpenURL("https://chickenonaraft.com/");
            print("Option 1");
        }

        else // B Test (No Audio)
        {
            Application.OpenURL("http://www.patience-is-a-virtue.org/");
            print("Option 2");
        }

        print("quit");
        //Application.Quit();
        Screen.fullScreen = false;
    }

    public void RageEndGame()
    {
        playerData.ended = true;
        StartCoroutine(database.Upload(playerData.username.ToString() + condition,
                        playerData.timeCounter.ToString(),
                        playerData.distanceCounter.ToString(),
                        playerData.ended.ToString()));

        EndGame();
    }

    public void rageQuit()
    {
        FreezePlayer();
        rageEndScreen.SetActive(true);
        exitHelpButtons.SetActive(false);
    }

    public void CancelRageQuit()
    {
        UnfreezePlayer();
        rageEndScreen.SetActive(false);
        exitHelpButtons.SetActive(true);
    }

}
