using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cell : MonoBehaviour
{
    
    public int id;
    public Logic logic;
    
    
    private void OnTriggerEnter(Collider other)
    {

        logic.PathCheck(id, this.gameObject);
        
    }

    private void OnTriggerExit(Collider other)
    {
        logic.lastID = id;
    }
}
