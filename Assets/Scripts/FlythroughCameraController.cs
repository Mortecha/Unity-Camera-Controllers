using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlythroughCameraController : MonoBehaviour
{
    public float movementSpeed = 50.0f;
    public float rotationSpeed = 50;
    public float lerpSpeed = 20.0f;

    private float rotationX = 0.0f;
    private float rotationY = 0.0f;

    private Vector3 targetPosition;

    void Start()
    {
        Screen.lockCursor = true;
        targetPosition = transform.position;
    }

    void Update()
    {
        Move();
        Rotate();
    }

    private void Move()
    {
        targetPosition += transform.forward * movementSpeed * Input.GetAxis("Vertical") * Time.deltaTime;
        targetPosition += transform.right * movementSpeed * Input.GetAxis("Horizontal") * Time.deltaTime;
        transform.position = Vector3.Lerp(transform.position, targetPosition, lerpSpeed * Time.deltaTime);
    }

    private void Rotate()
    {
        rotationX += Input.GetAxis("Mouse X") * rotationSpeed * Time.deltaTime;
        rotationY += Input.GetAxis("Mouse Y") * rotationSpeed * Time.deltaTime;
        transform.localRotation = Quaternion.AngleAxis(rotationX, Vector3.up);
        transform.localRotation *= Quaternion.AngleAxis(rotationY, Vector3.left);
    }
}
