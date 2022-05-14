using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Player : MonoBehaviour
{
    [SerializeField] private float _jumpForce;
    private bool _isGrounded;
    private Rigidbody _rigidbody;

    private void Start()
    {
        _isGrounded = true;
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        Jump();
    }

    private void Jump()
    {
        if(Input.GetMouseButtonDown(0) && _isGrounded)
        {
            _isGrounded = false;
            _rigidbody.AddForce(Vector3.up * _jumpForce);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.TryGetComponent(out Path path))
        {
            _isGrounded = true;
        }
    }
}
