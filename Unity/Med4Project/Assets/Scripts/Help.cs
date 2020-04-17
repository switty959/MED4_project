using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Help : MonoBehaviour
{

    public Canvas canvas;
    void Start()
    {
        
        Invoke("ShowInstructions", 2);

    }

    private void ShowInstructions()
    {

        canvas.gameObject.SetActive(true);
        
    }

    public void CloseInstructions()
    {
        canvas.gameObject.SetActive(false);
    }
}
