using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneScript : MonoBehaviour
{
    Rigidbody myRigidbody;
    public bool canFly = false;
    public bool isTouching = false;
    public GameObject player;
    public GameObject camera;
    CameraFollow cameraScript;
    // Start is called before the first frame update
    void Start()
    {
        cameraScript = camera.GetComponent<CameraFollow>();
        myRigidbody = GetComponent<Rigidbody>();
        canFly = false;

    }

    // Update is called once per frame
    void Update()
    {
        if (canFly)
        {
            isTouching = false;
            if (Input.GetKey(KeyCode.D))
            {
                myRigidbody.AddForce(transform.up * 5);
            }
            if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                myRigidbody.AddForce(transform.up * 5000);
            }
            if (Input.GetKey(KeyCode.A))
            {
                myRigidbody.AddForce(-transform.up * 5);
            }
            if (Input.GetKey(KeyCode.W))
            {
                transform.Rotate(0, 0, -0.2f, Space.World);
            }
            if (Input.GetKey(KeyCode.S))
            {
                transform.Rotate(0, 0, 0.2f, Space.World);
            }
            if (Input.GetKeyDown(KeyCode.E))
            {
                player.SetActive(true);
                player.transform.position = transform.position;
                cameraScript.player = player;
                Destroy(gameObject);
                cameraScript.speed = 0.1f;
                cameraScript.cameraDistance = 12;
            }

        }
        if (isTouching)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                cameraScript.player = gameObject;
                cameraScript.cameraDistance = 70;
                cameraScript.speed = 0.01f;
                player.SetActive(false);
                canFly = true;
            }
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "player")
        {
            isTouching = true;
        }
    }
}