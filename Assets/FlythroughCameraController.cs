using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlythroughCameraController : MonoBehaviour
{
    public float movementSpeed = 20.0f;
    public float rotationSpeed = 720.0f;

    void Update()
    {
        if (Input.GetKey(KeyCode.W))
            transform.position += transform.forward * movementSpeed * Time.deltaTime;
        else if (Input.GetKey(KeyCode.S))
            transform.position -= transform.forward * movementSpeed * Time.deltaTime;

        if (Input.GetKey(KeyCode.A))
            transform.position -= transform.right * movementSpeed * Time.deltaTime;
        else if (Input.GetKey(KeyCode.D))
            transform.position += transform.right * movementSpeed * Time.deltaTime;

        if (Input.GetKey(KeyCode.Q))
            transform.position -= transform.up * movementSpeed * Time.deltaTime;
        else if (Input.GetKey(KeyCode.E))
            transform.position += transform.up * movementSpeed * Time.deltaTime;

        if (Input.GetMouseButton(1) || Input.GetMouseButton(2))
        {
            float x = Input.GetAxis("Mouse X") * Time.deltaTime * 50 * rotationSpeed * Mathf.Deg2Rad;
            float y = Input.GetAxis("Mouse Y") * Time.deltaTime * 50 * rotationSpeed * Mathf.Deg2Rad;

            Vector3 localEulerAngles = transform.localEulerAngles;
            localEulerAngles.x -= y;
            localEulerAngles.y += x;
            transform.localEulerAngles = localEulerAngles;
            
        }
    }
}
