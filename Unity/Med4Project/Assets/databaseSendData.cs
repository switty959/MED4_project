using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class databaseSendData : MonoBehaviour
{
    // Start is called before the first frame update
    string timeSpent;
    string distanceTraveled;
    string username;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("I have beeen hit!");
            username = "bob er sej";
            timeSpent =  other.GetComponent<movementScript>().timeCounter.ToString();
            distanceTraveled = other.GetComponent<movementScript>().distanceCounter.ToString();
            StartCoroutine(Upload(username, timeSpent, distanceTraveled));
            Debug.Log("timer :" + timeSpent);
            Debug.Log("distance :" + distanceTraveled);
            Debug.Log("username : "+username);
        }
    }

   
    IEnumerator Upload(string playerName, string timer,string distanceCounter)
    {
        WWWForm form = new WWWForm();
        form.AddField("playerName", playerName);
        form.AddField("timer", timer);
        form.AddField("distance", distanceCounter);


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
