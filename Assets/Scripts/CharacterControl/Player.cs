using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Player : MonoBehaviour
{
    [SerializeField] PlayerInput playerInput;
    [SerializeField] float moveSpeed = 5f;


    Rigidbody2D rbody;

    private void Awake()
    {
        rbody = GetComponent<Rigidbody2D>();
    }

    private void OnEnable()
    {
        playerInput.onMove += Move;
        playerInput.onStopMove += StopMove;
    }

    void Start()
    {
        rbody.gravityScale = 0f;
        playerInput.EnablePlayerControlMap();
    }

    private void OnDisable()
    {
        playerInput.onMove -= Move;
        playerInput.onStopMove -= StopMove;
    }

    private void StopMove()
    {
        rbody.velocity = Vector2.zero;
    }

    private void Move(Vector2 moveInput)
    {
        rbody.velocity = moveInput * moveSpeed;
    }

    void Update()
    {
        
    }
}
