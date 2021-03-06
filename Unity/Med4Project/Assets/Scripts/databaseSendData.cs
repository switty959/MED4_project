﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class databaseSendData : MonoBehaviour
{
    // Start is called before the first frame update
    string timeSpent;
    string distanceTraveled;
    string username;
    string rageQuit;
    bool sendData = false;
    public Text usernameHolder;
    public Help help;
    

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && sendData == false)
        {
            username = GameObject.Find("userNameHolder").GetComponent<generateUserName>().username;
            usernameHolder.text ="Code: "+ username;
            timeSpent =  other.GetComponent<movementScript>().timeCounter.ToString();
            distanceTraveled = other.GetComponent<movementScript>().distanceCounter.ToString();
            rageQuit = other.GetComponent<movementScript>().ended.ToString();
            StartCoroutine(Upload(username + help.condition, timeSpent, distanceTraveled,rageQuit));
            Debug.Log("timer :" + timeSpent);
            Debug.Log("distance :" + distanceTraveled);
            Debug.Log("username : "+username);
            sendData = true;
        }
    }

   
    public IEnumerator Upload(string playerName, string timer,string distanceCounter,string rageQuit)
    {
        WWWForm form = new WWWForm();
        form.AddField("playerName", playerName);
        form.AddField("timer", timer);
        form.AddField("distance", distanceCounter);
        form.AddField("rageQuit", rageQuit);


        UnityWebRequest www = UnityWebRequest.Post("http://switty.dk/SendData.php", form);
        yield return www.SendWebRequest();

        if (www.isNetworkError || www.isHttpError)
        {
            Debug.Log(www.error);
        }
        else
        {
            Debug.Log("Form upload complete!");
        }
    }

}
