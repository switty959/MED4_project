﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class followPlayer : MonoBehaviour
{
    public GameObject player;       //Public variable to store a reference to the player game object
    private string playerTag = "Player";

    Vector3 offset;         //Private variable to store the offset distance between the player and camera
    void Start()
    {
        player = GameObject.FindGameObjectWithTag(playerTag);
        //Calculate and store the offset value by getting the distance between the player's position and camera's position.
        offset = transform.position - player.transform.position;
    }

    // LateUpdate is called after Update each frame
    void Update()
    {
        // Set the position of the camera's transform to be the same as the player's, but offset by the calculated offset distance.
        transform.position = player.transform.position + offset;
    }
}
