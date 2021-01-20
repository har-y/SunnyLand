using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _sprite;
    [SerializeField] private Transform _groundPoint;
    [SerializeField] private LayerMask _ground;

    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _jumpForce;

    private Rigidbody2D _rb;
    private Animator _animator;

    private float _horizontal;

    private bool _isGrounded;
    private bool _canJumpAgain;

    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
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
                _canJumpAgain = true;
            }
            else
            {
                if (_canJumpAgain)
                {
                    _rb.velocity = new Vector2(_rb.velocity.x, _jumpForce);
                    _canJumpAgain = false;
                }
            }
        }

        if (_rb.velocity.x < 0)
        {
            _sprite.flipX = true;
        }
        else if (_rb.velocity.x > 0)
        {
            _sprite.flipX = false;
        }

        _animator.SetFloat("moveSpeed", Mathf.Abs(_rb.velocity.x));
        _animator.SetBool("isGrounded", _isGrounded);
        _animator.SetBool("canJumpAgain", !_canJumpAgain);
    }
}
