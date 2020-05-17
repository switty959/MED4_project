using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instructions : MonoBehaviour
{
    public Canvas canvas;
    // Phrygian scale = ominous
    void Start()
    {
        Invoke("ShowInstructions", 2);
        
    }

    private void ShowInstructions()
    {
        canvas.enabled = true;
        print("called");   
    }

    public void CloseInstructions()
    {
        canvas.enabled = false;
    }

}
