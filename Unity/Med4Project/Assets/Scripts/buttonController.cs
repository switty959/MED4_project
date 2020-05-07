using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class buttonController : MonoBehaviour
{

    public GameObject[] buttonPanels;
    public Slider slider;
    private AudioSource audioSource;
    private float sliderValue;


    public void Start()
    {
        audioSource = GetComponent<AudioSource>();
    
    }
    public void Update()
    {
        sliderValue = slider.value; 
        AkSoundEngine.SetRTPCValue("PanSilder",sliderValue);


        if(buttonPanels[1].activeInHierarchy == true)
        {
            audioSource.volume = Mathf.Lerp(audioSource.volume, 0f, Time.deltaTime);
        }
    }
    public void StartGame(int level)
    {
        Debug.Log("i was pressed");
        SceneManager.LoadScene(level);
        
    }

    public void Confirm()
    {
        slider.value = 0;        
        buttonPanels[0].SetActive(false);
        buttonPanels[1].SetActive(true);
        
    }

    public void ExitGame()
    {
        Application.Quit();
    }

   // public void Help()
    //{
      //  ShowInstructions();
   // }


}
