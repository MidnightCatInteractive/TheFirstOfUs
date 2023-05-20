using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Xml.Linq;
using UnityEngine;

public class MovementScript : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] private float moveSpeed = 7f;
    [SerializeField] private float groundDrag;

    [Header("Jumping")]
    [SerializeField] private float jumpForce;
    [SerializeField] private float jumpCooldown;
    [SerializeField] private float airMultiplier;
    private bool readyToJump;

    [Header("Ground Check")]
    [SerializeField] private float playerHeight;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private float groundDistance = 0.4f;
    [SerializeField] private LayerMask _groundLayer;
    private bool isGrounded;

    [SerializeField] private Transform orientation;
    

    [Header("Input Check")]
    private float horizontalInput;
    private float verticalInput;

    private Vector3 moveDirection;
    private Rigidbody _rigidbody;

    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _rigidbody.freezeRotation = true;
        readyToJump = true;
    }

    void Update()
    {
        if (!PauseMenuScript.isPaused)
        {
            isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, _groundLayer);
            GetInput();
            if (isGrounded)
                _rigidbody.drag = groundDrag;
            else _rigidbody.drag = 0;

            SpeedControl();
            MovePlayer();
        }
    }

    private void GetInput()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");

        if (Input.GetKey(KeyCode.Space) && readyToJump && isGrounded)
        {
            readyToJump = false;
            Jump();
            Invoke(nameof(ResetJump), jumpCooldown);
        }
    }

    private void MovePlayer()
    {
        if (isGrounded)
        {
            _rigidbody.AddForce(moveDirection.normalized * moveSpeed * 2f, ForceMode.Force);
        }
        else if (!isGrounded)
        {
            _rigidbody.AddForce(moveDirection.normalized * moveSpeed * 2f * airMultiplier, ForceMode.Force);
        }
        if (Input.GetKey(KeyCode.LeftShift)) {
            moveDirection = orientation.forward * verticalInput + orientation.right * horizontalInput;
            _rigidbody.AddForce(moveDirection.normalized * moveSpeed * 10f, ForceMode.Force);
        }
        else {
            moveDirection = orientation.forward * verticalInput + orientation.right * horizontalInput;
            _rigidbody.AddForce(moveDirection.normalized * moveSpeed * 2f, ForceMode.Force);
        }
    }

    private void SpeedControl()
    {
        Vector3 flatVelocity = new Vector3(_rigidbody.velocity.x, 0f, _rigidbody.velocity.z);
        if (flatVelocity.magnitude > moveSpeed)
        {
            Vector3 limitedVelocity = flatVelocity.normalized * moveSpeed;
            _rigidbody.velocity = new Vector3(limitedVelocity.x, _rigidbody.velocity.y, limitedVelocity.z);
        }
    }

    private void Jump()
    {
        _rigidbody.velocity = new Vector3(_rigidbody.velocity.x, 0f, _rigidbody.velocity.z);
        _rigidbody.AddForce(transform.up * jumpForce, ForceMode.Impulse);
    }

    private void ResetJump()
    {
        readyToJump = true;
    }
}
