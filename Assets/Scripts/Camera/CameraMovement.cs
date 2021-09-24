using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour {
    public bool canRotate = true;
    public Transform target;
    public float distance = 10.0f;
    public float height = 5.0f;
    public float heightDamping = 2.0f;
    public float rotationDamping = 3.0f;

    private float wantedRotationAngle;
    private float wantedHeight;
    private float currentRotationAngle;
    private float currentHeight;
    private Quaternion currentRotation;


    void LateUpdate() {
        if (target) {
            wantedRotationAngle = target.eulerAngles.y;
            wantedHeight = target.position.y + height;
            currentRotationAngle = transform.eulerAngles.y;
            currentHeight = transform.position.y;

            // Damp the rotation around the y-axis
            currentRotationAngle = Mathf.LerpAngle (currentRotationAngle, wantedRotationAngle, rotationDamping * Time.deltaTime);

            // Damp the height
            currentHeight = Mathf.Lerp (currentHeight, wantedHeight, heightDamping * Time.deltaTime);

            // Convert the angle into a rotation
            currentRotation = Quaternion.Euler (0, currentRotationAngle, 0);

            // Set the position of the camera on the x-z plane to:
            // distance meters behind the target
            transform.position = target.position;
            transform.position -= currentRotation * Vector3.forward * distance;

            // Set the height of the camera
            transform.position = new Vector3 (transform.position.x, currentHeight, transform.position.z);

            // Always look at the target
            if (canRotate)
                transform.LookAt (target);
        }
    }
}
