using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Bil : MonoBehaviour
{
    Rigidbody myRigidbody;
    public bool canDrive = false;
    public bool isTouching = false;
    public GameObject player;
    public GameObject camera;
    CameraFollow cameraScript;
    bool boost;
    int carSpeed;
    // Start is called before the first frame update
    void Start()
    {
        cameraScript = camera.GetComponent<CameraFollow>();
        myRigidbody = GetComponent<Rigidbody>();
        canDrive = false;
        boost = true;
        carSpeed = 5;
    }

    // Update is called once per frame
    void Update()
    {
        if (canDrive)
        {
            isTouching = false;
            if (Input.GetKey(KeyCode.D))
            {
                myRigidbody.AddForce(-carSpeed, 0, 0);
            }
            if (Input.GetKey(KeyCode.A))
            {
                myRigidbody.AddForce(carSpeed, 0, 0);
            }
            if (Input.GetKey(KeyCode.LeftShift) && boost)
            {
                carSpeed = 10;
                boost = false;
                StartCoroutine(boostDuration());
            }
            if (Input.GetKeyDown(KeyCode.E))
            {
                player.SetActive(true);
                player.transform.position = transform.position;
                cameraScript.player = player;
                Destroy(gameObject);
                cameraScript.speed = 0.1f;
            }

        }
        if (isTouching)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                cameraScript.player = gameObject;
                cameraScript.speed = 0.01f;
                player.SetActive(false);
                canDrive = true;
            }
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "player")
        {
            isTouching = true;
        }

    }

    IEnumerator boostDuration()
    {
        print("soon");
        yield return new WaitForSeconds(2);
        carSpeed = 5;
        print("done");
        StartCoroutine(boostCooldown());
    }
    IEnumerator boostCooldown()
    {
        yield return new WaitForSeconds(2);
        boost = true;
    }
}
