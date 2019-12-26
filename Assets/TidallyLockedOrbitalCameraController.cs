using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TidallyLockedOrbitalCameraController : MonoBehaviour
{
    public GameObject target;
    public float rotationSpeed = 8.0f;
    public float cameraZoom = 10.0f;

    private float xRotation = 0;
    private float yRotation = 0;

    void Start()
    {
        transform.position = target.transform.position - transform.forward * cameraZoom;
    }

    void Update()
    {
        if(Input.GetMouseButton(0))
        {
            xRotation += Input.GetAxis("Mouse X") * rotationSpeed;
            yRotation += Input.GetAxis("Mouse Y") * rotationSpeed;

            if (yRotation > 90.0f)
                yRotation = 90.0f;
            if (yRotation < -90.0f)
                yRotation = -90.0f;

            transform.rotation = Quaternion.Euler(0, xRotation, 0) * Quaternion.Euler(-yRotation, 0, 0);
            transform.position = target.transform.position - transform.forward * cameraZoom;
        }
    }
}
