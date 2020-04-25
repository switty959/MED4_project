using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Correct : MonoBehaviour
{
    public AudioSource audioSource;
    public float rate;
    public bool entered;
    public int counter;
    public int mod;
    private collisionChecker leftCol, rightCol, backCol, forwardCol;


    private void Start()
    {
        counter = 0;
        leftCol = transform.Find("Left").GetComponent<collisionChecker>();
        rightCol = transform.Find("Right").GetComponent<collisionChecker>();
        forwardCol = transform.Find("Forward").GetComponent<collisionChecker>();
        backCol = transform.Find("Back").GetComponent<collisionChecker>();


    }

    public enum Karma
    { Correct, Incorrect }

    public enum Direction
    { Left, Right, Forward, Back }

    public Karma karma;
    public Direction direction;

    public void OnTriggerEnter(Collider collision)
    {
        counter +=  1;
        mod = counter % 2;
        entered = true;

        //if (karma == Karma.Incorrect && mod == 1)
        //{
        //    audioSource.volume += 0.1f;
            
        //}

        //if (karma == Karma.Incorrect && mod == 0)
        //{
        //    audioSource.volume -= 0.1f;
        //}

        //entered = true;

        //if (karma == Karma.Correct && mod == 1)
        //{
        //    audioSource.volume -= 0.1f;
        //}

        //if (karma == Karma.Correct && mod == 0)
        //{
        //    audioSource.volume += 0.1f;
        //}
    }

    public void OnTriggerExit(Collider collision)
    {
        entered = false;
    }


    public void Update()
    {
        if (entered == true)
        {
            if ((leftCol.hit && direction == Direction.Left)|| (rightCol.hit && direction == Direction.Right) || (forwardCol.hit && direction == Direction.Forward) || (backCol.hit && direction == Direction.Back))
            {
                audioSource.pitch = Mathf.Lerp(audioSource.pitch, 1.0f, rate);
                //audioSource.volume = 0.0f;
            }

            if ((leftCol.hit && direction != Direction.Left) || (rightCol.hit && direction != Direction.Right) || (forwardCol.hit && direction != Direction.Forward) || (backCol.hit && direction != Direction.Back))
            {
                audioSource.pitch = Mathf.Lerp(audioSource.pitch, 0.85f, rate);
                //audioSource.volume = Mathf.Lerp(audioSource.volume, 1.0f, rate);
            }

            

        }


    }
    //public void Update()
    //{
    //    if (entered == true)
    //    {
    //        if (karma == Karma.Correct && mod == 0)
    //        {
    //            audioSource.pitch = Mathf.Lerp(audioSource.pitch, 2.0f, rate);

    //        }

    //        if (karma == Karma.Correct && mod == 1)
    //        {
    //            audioSource.pitch = Mathf.Lerp(audioSource.pitch, 1.5f, rate);

    //        }
    //        if (karma == Karma.Incorrect && mod == 0)
    //        {
    //            audioSource.pitch = Mathf.Lerp(audioSource.pitch, 1.5f, rate);
    //        }

    //        if (karma == Karma.Incorrect && mod == 1)
    //        {
    //            audioSource.pitch = Mathf.Lerp(audioSource.pitch,   0.0f, rate);
    //        }

    //    }


    //}


}
