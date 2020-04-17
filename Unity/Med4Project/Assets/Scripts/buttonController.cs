﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class buttonController : MonoBehaviour
{

    public GameObject[] buttonPanels;
    public Slider slider;
    private AudioSource audioSource;

    public void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    public void Update()
    {
        audioSource.panStereo = slider.value;

        if(buttonPanels[1].activeInHierarchy == true)
        {
            audioSource.volume = Mathf.Lerp(audioSource.volume, 0f, Time.deltaTime);
        }
    }
    public void StartGame(int level)
    {
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

}
