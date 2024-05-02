using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    public GameObject player;
    public int cameraDistance = 12;
    public float speed = 0.1f;

    Vector3 velocity;
    // Start is called before the first frame update
    void Start()
    {
        cameraDistance = 12;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 targetPosition = player.transform.position + new Vector3(0, 2, cameraDistance);
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, speed);
    }
}
