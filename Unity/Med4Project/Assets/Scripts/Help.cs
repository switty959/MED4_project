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
    private bool sentData;
    public GameObject codePanel;
    public Text codePanelText;
    void Start()
    {
        string username = GameObject.Find("userNameHolder").GetComponent<generateUserName>().username;
        for (int i = 0; i < UICode.Length; i++)
        {
            UICode[i].text = "Code: " + username.ToString();
        }
        
        ShowInstructions();

        usernameInt = int.Parse(username);
        /*
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
        */
        audioCues.enabled = false;
        orb.enabled = false;
        condition = "b";
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
        print(usernameInt);/*
        if (usernameInt % 2 == 0) // A Test (Audio)
        {
            Application.OpenURL("https://forms.gle/YKvXj2NwqAsw24xT7");
            print("Option 1");
        }

        else // B Test (No Audio)
        {
            Application.OpenURL("https://forms.gle/XiNXVMwZpbaivMndA");
            print("Option 2");
        }*/

        Application.OpenURL("https://forms.gle/XiNXVMwZpbaivMndA");
        print("Option 2");

        print("quit");

        Screen.SetResolution(1280, 720, false);
        codePanelText.text = playerData.username;
        rageEndScreen.SetActive(false);
        codePanel.SetActive(true);

    }

    public void RageEndGame()
    {
        playerData.ended = true;
        if (sentData == false)
        {
            StartCoroutine(database.Upload(playerData.username.ToString() + condition,
                                    playerData.timeCounter.ToString(),
                                    playerData.distanceCounter.ToString(),
                                    playerData.ended.ToString()));
            sentData = true;
        }
        

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
        playerData.ended = false;
        UnfreezePlayer();
        rageEndScreen.SetActive(false);
        exitHelpButtons.SetActive(true);
    }

}
