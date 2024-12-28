using System;
using Unity.VisualScripting;
using UnityEngine;

[RequireComponent (typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    public float _speed;
    bool _canMove = true;
    Vector3 _velocity = Vector3.zero;

    bool _isGrounded;
    bool _canJump;
    public float _jumpForce;


    public Transform _groundCheckLeft;
    public Transform _groundCheckRight;

    Rigidbody2D _rb;

    void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }


   void Update()
    {
        if (Input.GetButtonDown("Jump"))
            _canJump = true;
        
    }

    void FixedUpdate()
    {
        if (!_canMove)
            return;

        _isGrounded = Physics2D.OverlapArea(_groundCheckLeft.position, _groundCheckRight.position);
        move();

    }

    private void move()
    {
        float horizontal = Input.GetAxisRaw("Horizontal") * _speed * Time.fixedDeltaTime;
        Vector2 newPos = new Vector2(horizontal, _rb.linearVelocity.y);
        _rb.linearVelocity = Vector3.SmoothDamp(_rb.linearVelocity, newPos, ref _velocity, 0.05f);

        if (_canJump && _isGrounded)
            _rb.AddForce(new Vector2(0, _jumpForce));

        _canJump = false;
    }
}
