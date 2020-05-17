using System.Collections;
using System.Collections.Generic;
using System.IO.Ports;
using UnityEngine;

public class arduinoController : MonoBehaviour
{

    public float movementSpeed;
    public Vector3 movement;
    Rigidbody rb;
    public char direction;
    SerialPort sp = new SerialPort("COM3",9600);

    // Start is called before the first frame update
    void Start()
    {
        rb = this.gameObject.GetComponent<Rigidbody>();
        sp.Open();
        sp.ReadTimeout = 1;
    }

    private void Update()
    {

        if (sp.IsOpen)
        {
            try
            {
                direction = System.Convert.ToChar(sp.ReadByte());
                Debug.Log(direction);
            }
            catch (System.Exception)
            {
            }
        }
        if (direction =='W')
        {
            movement = new Vector3(0, 0, 1);
        }
        if (direction == 'S')
        {
            movement = new Vector3(0, 0, -1);
        }
        if (direction == 'A')
        {
            movement = new Vector3(-1, 0, 0);
        }
        if (direction == 'D')
        {
            movement = new Vector3(1, 0, 0);
        }
       
    }

    void FixedUpdate()
    {
        moveCharacter(movement);
    }

    void moveCharacter(Vector3 direction)
    {
        rb.MovePosition((Vector3)transform.position + (direction * movementSpeed * Time.deltaTime));
    }
}
