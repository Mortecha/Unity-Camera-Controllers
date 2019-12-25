using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopDownShooterCameraController : MonoBehaviour
{
    public GameObject target;

    private readonly float cameraRayLength = 1000f;

    public float lerpSpeed = 5f;

    void Start()
    {
        transform.position = target.transform.position;
    }

    void FixedUpdate()
    {
        Ray cameraRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit floorHit;

        if (Physics.Raycast(cameraRay, out floorHit, cameraRayLength, LayerMask.GetMask("Ground")))
        {
            float newPositionX = target.transform.position.x + (floorHit.point.x - target.transform.position.x) / 2;
            float newPositionZ = target.transform.position.z + (floorHit.point.z - target.transform.position.z) / 2;

            Vector3 newPosition = new Vector3(newPositionX, target.transform.position.y, newPositionZ);
            transform.position = Vector3.Lerp(transform.position, newPosition, lerpSpeed * Time.deltaTime);
        }
    }
}
