using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Rigidbody myRigidbody;
    // Start is called before the first frame update
    void Start()
    {
        myRigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.D))
        {
            myRigidbody.AddForce(-3, 0, 0);
        }
        if (Input.GetKey(KeyCode.A))
        {
            myRigidbody.AddForce(3, 0, 0);
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            myRigidbody.AddForce(0, 5, 0, ForceMode.Impulse);
        }
    }
}
