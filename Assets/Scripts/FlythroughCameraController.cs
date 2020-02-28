using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlythroughCameraController : MonoBehaviour
{
    public float movementSpeed = 0.5f;
    public float rotationSpeed = 720.0f;
    public float lerpSpeed = 20.0f;

    private Vector3 currentPosition;
    private Vector3 targetPosition;

    void Start()
    {
        currentPosition = targetPosition = transform.position;
    }

    void Update()
    {
        currentPosition = transform.position;
        if (Input.GetKey(KeyCode.W))
            targetPosition += transform.forward * movementSpeed;
        else if (Input.GetKey(KeyCode.S))
            targetPosition -= transform.forward * movementSpeed;

        if (Input.GetKey(KeyCode.A))
            targetPosition -= transform.right * movementSpeed;
        else if (Input.GetKey(KeyCode.D))
            targetPosition += transform.right * movementSpeed;

        if (Input.GetKey(KeyCode.Q))
            targetPosition -= transform.up * movementSpeed;
        else if (Input.GetKey(KeyCode.E))
            targetPosition += transform.up * movementSpeed;

        transform.position = Vector3.Lerp(currentPosition, targetPosition, lerpSpeed * Time.deltaTime);

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
