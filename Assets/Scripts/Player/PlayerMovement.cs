using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
    public float speed = 3.0f;
    public float mouseSensitivity = 2.0f;

    private Rigidbody rb;

    void Start() {
        rb = GetComponent<Rigidbody>();
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update() {
        LookAround();
        Move();

        if (Input.GetKeyDown(KeyCode.Escape)) {
            Cursor.lockState = CursorLockMode.None;
        }
    }

    void Move() {
        float xaxis = Input.GetAxisRaw("Horizontal");
        float zaxis = Input.GetAxisRaw("Vertical");

        Vector3 xmovement = transform.right * xaxis;
        Vector3 zmovement = transform.forward * zaxis;

        rb.velocity = (xmovement + zmovement).normalized * speed;
    }

    void LookAround() {
        rb.MoveRotation(
            rb.rotation * Quaternion.Euler(
                new Vector3(
                    0,
                    Input.GetAxis("Mouse X") * mouseSensitivity,
                    0
                )
            )
        );
    }
}
