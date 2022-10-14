using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof (Rigidbody))]
public class PlayerMovement : MonoBehaviour
{
    [Space]
    [Header("Audio Options")]
    [SerializeField] float timeBetweenSteps;
    [SerializeField] AudioClip[] footsteps;
    [SerializeField] AudioClip[] jump;
    [SerializeField] AudioClip[] land;
    [Space]
    [Header("Ground Check")]
    [Tooltip("Point from which to check for ground collisions")]
    [SerializeField] Transform feet;
    [Tooltip("The children which hold items")]
    [SerializeField] Transform rightHand;
    [Tooltip("The children which hold items")]
    [SerializeField] Transform leftHand;
    [Tooltip("Distance from the feet object which will count as being grounded")]
    [SerializeField] float groundDistance = 0.2f;
    [Tooltip("The layer which is considered ground")]
    [SerializeField] LayerMask ground;


    Rigidbody rigidBody;
    CapsuleCollider capsuleCollider;
    Vector2 input;
    bool isGrounded;
    bool isCrouching = false;
    float currentMoveSpeed;
    float lastStep = 0;

    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
        capsuleCollider = GetComponent<CapsuleCollider>();
        currentMoveSpeed = PlayerStats.Instance.moveSpeed;
    }

    void FixedUpdate()
    {
        isGrounded = Physics.CheckSphere(feet.position, groundDistance, ground);
        Vector3 movement = (transform.right * input.x + transform.forward * input.y) * currentMoveSpeed;
        movement += new Vector3(0, rigidBody.velocity.y, 0);
        rigidBody.velocity = movement;
        if (isGrounded && (movement.x != 0 || movement.z != 0 || movement.y < -1) && Time.time - lastStep > timeBetweenSteps / currentMoveSpeed)
        {
            SFXController.Instance.PlaySFX(footsteps, 0.5f);
            lastStep = Time.time;
        }
    }

    void OnMove(InputValue value)
    {
        input = value.Get<Vector2>();
    }

    void OnJump()
    {
        if (isGrounded) {
            rigidBody.velocity = new Vector3(rigidBody.velocity.x, Mathf.Sqrt((PlayerStats.Instance.jumpHeight + 0.2f) * -2 * Physics.gravity.y), rigidBody.velocity.z);
            SFXController.Instance.PlaySFX(jump);
        }
    }

    void OnJumpRelease()
    {
        if (rigidBody.velocity.y > 0) rigidBody.velocity = new Vector3(rigidBody.velocity.x, rigidBody.velocity.y * 0.5f, rigidBody.velocity.z);
    }

    void OnCrouch(InputValue action)
    {
        if (!PlayerStats.Instance.hasCrouch) return;
        bool isPressed = (action.Get().ToString() == "1");
        if (isPressed && !isCrouching) Crouch();
        if (!isPressed && isCrouching) StandUp();
    }

    void Crouch()
    {
        capsuleCollider.height *= 0.5f;
        isCrouching = true;
    }

    void StandUp()
    {
        capsuleCollider.height *= 2;
        isCrouching = false;
    }

    void OnSprint(InputValue action)
    {
        if (!PlayerStats.Instance.hasSprint) return;
        bool isPressed = (action.Get().ToString() == "1");
        if (isPressed) currentMoveSpeed = PlayerStats.Instance.moveSpeed * 2;
        else currentMoveSpeed = PlayerStats.Instance.moveSpeed;
    }
}
