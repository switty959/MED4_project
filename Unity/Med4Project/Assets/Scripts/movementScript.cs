
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class movementScript : MonoBehaviour
{

    public float movementSpeed;
    public Vector3 movement;
    Rigidbody rb;
    public float distanceCounter;
    public float timeCounter;
    public bool ended;
    
    private SimpleCharacterControlFree controller;
    public GameObject manager;



    // Start is called before the first frame update
    void Start()
    {
        rb = this.gameObject.GetComponent<Rigidbody>();
        
        controller = gameObject.GetComponent<SimpleCharacterControlFree>();
    }

    private void Update()
    {
        //movement = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));

        if (distanceCounter > 0 && ended != true) timeCounter += Time.deltaTime;

        if (controller.m_currentV > .01 || controller.m_currentH > 0.01 || controller.m_currentV < -.01 || controller.m_currentH <- 0.01)
        {
            //AkSoundEngine.PostEvent("FootStep", gameObject);
        }

        
        

        
        
    }

    void FixedUpdate()
    {
        //    moveCharacter(movement);

        //}

        //void moveCharacter(Vector3 direction)
        //{
        //    rb.MovePosition((Vector3)transform.position + (direction * movementSpeed * Time.deltaTime));

        //if (controller.velocity != Vector3.zero)
        //{
            distanceCounter += Mathf.Abs(controller.m_currentH + controller.m_currentV)*Time.deltaTime;
            
        //}

    }

    void OnTriggerEnter(Collider other)
    {

        if (other.tag == "End")
        {
            ended = true;
            manager.GetComponent<Help>().End();
        }
    }
}
