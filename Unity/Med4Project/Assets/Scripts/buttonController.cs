using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class buttonController : MonoBehaviour
{

    public GameObject[] buttonPanels;
    public Slider slider;
    private float sliderValue;



    public void Update()
    {
        sliderValue = slider.value; 
        AkSoundEngine.SetRTPCValue("PanSilder",sliderValue);


        
    }
    public void StartGame(int level)
    {
        AkSoundEngine.StopAll();
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
