using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
    public float speed = 3.0f;

    private Rigidbody rb;
    private Vector3 movement;
    void Start() {
        rb = GetComponent<Rigidbody>();
    }

    void Update() {
        HandleInputs();
    }

    void FixedUpdate() {
        Move();
    }

    void HandleInputs() {
        float xmovement = Input.GetAxisRaw("Horizontal") * speed;
        float ymovement = Input.GetAxisRaw("Vertical") * speed;

        movement = new Vector3(xmovement, rb.velocity.y, ymovement);
    }

    void Move() {
        rb.velocity = movement;
    }
}
