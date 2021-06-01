using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public float Speed = 5f;
    public float JumpHeight = 2f;
    public float GroundDistance = 0.2f;
    public LayerMask Ground;
    public Joystick joystick;
    public Button button;

    private Rigidbody _body;
    private Vector3 _inputs = Vector3.zero;
    private bool _isGrounded = true;
    private Transform _groundChecker;
    private bool buttonClicked;

    void Start()
    {
        _body = GetComponent<Rigidbody>();
        _groundChecker = transform.GetChild(0);
        Button jumpButton = button.GetComponent<Button>();
        jumpButton.onClick.AddListener(JumpButtonClicked);
    }

    private void JumpButtonClicked()
    {
         buttonClicked = true;
    }


    void Update()
    {
        _isGrounded = Physics.CheckSphere(_groundChecker.position, GroundDistance, Ground, QueryTriggerInteraction.Ignore);


        _inputs = Vector3.zero;
        _inputs.x = joystick.Horizontal;
        _inputs.z = joystick.Vertical;
        if (_inputs != Vector3.zero)
            transform.forward = _inputs;

        if (buttonClicked  && _isGrounded)
        {
            _body.AddForce(Vector3.up * Mathf.Sqrt(JumpHeight * -2f * (Physics.gravity.y * 0.5f)), ForceMode.VelocityChange);
            buttonClicked = false;
        }
        
    }


    void FixedUpdate()
    {
        _body.MovePosition(_body.position + _inputs * Speed * Time.fixedDeltaTime);
    }
    
}
