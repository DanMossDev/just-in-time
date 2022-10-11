using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof (Rigidbody))]
public class PlayerMovement : MonoBehaviour
{
    [Space]
    [Header("Movement Options")]

    [Space]
    [Header("Ground Check")]
    [Tooltip("Point from which to check for ground collisions")]
    [SerializeField] Transform feet;
    [Tooltip("Distance from the feet object which will count as being grounded")]
    [SerializeField] float groundDistance = 0.2f;
    [Tooltip("The layer which is considered ground")]
    [SerializeField] LayerMask ground;


    Rigidbody rigidBody;
    Vector2 input;
    bool isGrounded;

    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        isGrounded = Physics.CheckSphere(feet.position, groundDistance, ground);
        Vector3 movement = (transform.right * input.x + transform.forward * input.y) * PlayerStats.moveSpeed;
        movement += new Vector3(0, rigidBody.velocity.y, 0);
        rigidBody.velocity = movement;
    }

    void OnMove(InputValue value)
    {
        input = value.Get<Vector2>();
    }

    void OnJump()
    {
        if (isGrounded) rigidBody.velocity = new Vector3(rigidBody.velocity.x, Mathf.Sqrt((PlayerStats.jumpHeight + 0.2f) * -2 * Physics.gravity.y), rigidBody.velocity.z);
    }
}
