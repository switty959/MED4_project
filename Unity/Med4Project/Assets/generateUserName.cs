using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;


public class generateUserName : MonoBehaviour
{

    public string username;
    public int startvalue,endValue;
    public string[] usernamesFromDataBase;
    public GameObject usernameHolder;
    
    // Start is called before the first frame update
  
    private void Awake()
    {
        StartCoroutine(getText());
        DontDestroyOnLoad(this.gameObject);
       
       
    }


    private void Start()
    {
        generateANumber(startvalue,endValue);

        
    }
    IEnumerator getText()
    {
        UnityWebRequest www = UnityWebRequest.Get("http://switty.dk/nameCheck.php");
        yield return www.SendWebRequest();
        if (www.isNetworkError || www.isHttpError)
        {
            Debug.Log(www.error);
        }
        else
        {
            // Show results as text
            Debug.Log(www.downloadHandler.text);
            usernamesFromDataBase = www.downloadHandler.text.Split(':');

            // Or retrieve results as binary data
            byte[] results = www.downloadHandler.data;
        }
    }
        
    public void generateANumber(int minrange,int maxrange)
    {
        string newUsername = Random.Range(minrange,maxrange).ToString();

        for (int i = 0; i < usernamesFromDataBase.Length; i++)
        {
            if (newUsername == usernamesFromDataBase[i])
            {
                Debug.Log("error");
                generateANumber(minrange,maxrange);
            }
           
        }
        Debug.Log("new username has be generated");
        username = newUsername;
        usernameHolder.transform.GetChild(1).GetComponent<Text>().text = "Code: " + username;

    }

   
}
