﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement : MonoBehaviour
{
    Rigidbody _rigidbody;
    [SerializeField] private float movePower = 5;
    Vector3 move;
    [SerializeField] GameObject playerParticle;
    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        GetComponent<Rigidbody>().maxAngularVelocity = 25;
    }

    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        move= (z * Vector3.forward + x * Vector3.right).normalized;
        if(transform.position.y<0)
        {
            Instantiate(playerParticle, transform.position, transform.rotation);

            Destroy(gameObject);
        }
       // move= (z * Vector3.up + x * Vector3.up).normalized;
    }

    public void Move(Vector3 moveDirection)
    {
        _rigidbody.AddForce(moveDirection * movePower);
    }
    private void FixedUpdate()
    {
        Move(move);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.CompareTag("enemy") )
        {
            Instantiate(playerParticle, transform.position, transform.rotation);

            Destroy(gameObject);

        }
    }

}
