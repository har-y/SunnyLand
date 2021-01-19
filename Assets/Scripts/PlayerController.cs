using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Transform _groundPoint;
    [SerializeField] private LayerMask _ground;

    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _jumpForce;

    private Rigidbody2D _rb;

    private float _horizontal;

    private bool _isGrounded;

    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        _horizontal = Input.GetAxisRaw("Horizontal");
        _rb.velocity = new Vector2(_moveSpeed * _horizontal, _rb.velocity.y);

        _isGrounded = Physics2D.OverlapCircle(_groundPoint.position, 0.2f, _ground);

        if (Input.GetButtonDown("Jump"))
        {
            if (_isGrounded)
            {
                _rb.velocity = new Vector2(_rb.velocity.x, _jumpForce);
            }
        }
    }
}
