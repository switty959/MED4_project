using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collisionChecker : MonoBehaviour
{
    public bool hit;

    public void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            hit = true;
        }
    }

    public void OnTriggerExit(Collider collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            hit = false;
        }
    }

}
