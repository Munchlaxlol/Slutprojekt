using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jetpack : MonoBehaviour
{
    Rigidbody myRigidbody;
    public bool canUseJetpack = false;
    public bool isTouching = false;
    public GameObject player;
    public GameObject camera;
    CameraFollow cameraScript;
    bool isGrounded;
    // Start is called before the first frame update
    void Start()
    {
        //sätter upp variabler
        cameraScript = camera.GetComponent<CameraFollow>();
        myRigidbody = GetComponent<Rigidbody>();
        canUseJetpack = false;
        isGrounded = true;
    }

    // Update is called once per frame
    void Update()
    {
        //känner om man kan flyga och låter en börja flyga
        if (canUseJetpack)
        {
            if (Input.GetKey(KeyCode.Space))
            {
                myRigidbody.AddForce(0, 5, 0);
            }
            // om den inte rör marken kan den röra sig åt sidan
            if (isGrounded == false)
            {
                isTouching = false;
                if (Input.GetKey(KeyCode.D))
                {
                    myRigidbody.AddForce(-1, 0, 0);
                }
                if (Input.GetKey(KeyCode.A))
                {
                    myRigidbody.AddForce(1, 0, 0);
                }
                //om e trycks på tas jetpacken bort och byts ut mot spelaren. Kameran börjar följa spelaren istället för jetpacken.
                if (Input.GetKeyDown(KeyCode.E))
                {
                    player.SetActive(true);
                    player.transform.position = transform.position;
                    cameraScript.player = player;
                    Destroy(gameObject);
                    cameraScript.speed = 0.1f;
                }
            }
        }

        //om variabeln isTouching är sann och man trycker på e börjar kameran följa jetpacken och spelaren tas bort
        if (isTouching)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                cameraScript.player = gameObject;
                cameraScript.speed = 0.01f;
                player.SetActive(false);
                canUseJetpack = true;
            }
        }

    }

    //om jetpacken rör något med tagen "player" blir isTouching sann.
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "player")
        {
            isTouching = true;
        }
        // om den rör marken är isGrounded sann
        if(collision.gameObject.tag == "ground")
        {
            isGrounded = true;
        }

    }

    // om den slutar röra marken är isGrounded false
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "ground")
        {
            isGrounded = false;
        }
    }
}