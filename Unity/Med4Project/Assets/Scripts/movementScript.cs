
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


    // Start is called before the first frame update
    void Start()
    {
        rb = this.gameObject.GetComponent<Rigidbody>();
        
    }

    private void Update()
    {
        movement = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));

        if (distanceCounter > 0 && ended != true) timeCounter += Time.deltaTime;

    }

    void FixedUpdate()
    {
        moveCharacter(movement);
    }

    void moveCharacter(Vector3 direction)
    {
        rb.MovePosition((Vector3)transform.position + (direction * movementSpeed * Time.deltaTime));
        distanceCounter += Mathf.Abs(direction.x + direction.z);


    }

    void OnTriggerEnter(Collider other)
    {

        if (other.tag == "End")
        {
            ended = true;
        }
    }
}
