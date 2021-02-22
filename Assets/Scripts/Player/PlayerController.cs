using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _playerSprite;
    [SerializeField] private Transform _groundPoint;
    [SerializeField] private LayerMask _ground;

    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _jumpForce;
    [SerializeField] private float _bounceForce;
    [SerializeField] private float _knockBackTime;
    [SerializeField] private float _knockBackForce;

    public static PlayerController instance;

    public bool stopInput;

    public Rigidbody2D _rb;
    private Animator _animator;

    private float _horizontal;
    private float _knockBackCounter;

    private bool _isGrounded;
    private bool _canJumpAgain;

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!UIPauseMenu.instance.pause && !stopInput)
        {
            if (_knockBackCounter <= 0)
            {
                PlayerMove();
                PlayerJump();

                FlipSprite();
            }
            else
            {
                PlayerKnockBack();
            }
        }

        Animations();
    }

    private void PlayerMove()
    {
        _horizontal = Input.GetAxisRaw("Horizontal");
        _rb.velocity = new Vector2(_moveSpeed * _horizontal, _rb.velocity.y);
    }

    private void PlayerJump()
    {
        _isGrounded = Physics2D.OverlapCircle(_groundPoint.position, 0.2f, _ground);

        if (Input.GetButtonDown("Jump"))
        {
            if (_isGrounded)
            {
                _rb.velocity = new Vector2(_rb.velocity.x, _jumpForce);

                AudioManager.instance.PlaySoundClip(11);

                _canJumpAgain = true;
            }
            else
            {
                if (_canJumpAgain)
                {
                    _rb.velocity = new Vector2(_rb.velocity.x, _jumpForce);

                    AudioManager.instance.PlaySoundClip(11);

                    _canJumpAgain = false;
                }
            }
        }
    }

    private void PlayerKnockBack()
    {
        _knockBackCounter -= Time.deltaTime;

        if (!_playerSprite.flipX)
        {
            _rb.velocity = new Vector2(-_knockBackForce, _rb.velocity.y);
        }
        else
        {
            _rb.velocity = new Vector2(_knockBackForce, _rb.velocity.y);
        }
    }

    private void FlipSprite()
    {
        if (_rb.velocity.x < 0)
        {
            _playerSprite.flipX = true;
        }
        else if (_rb.velocity.x > 0)
        {
            _playerSprite.flipX = false;
        }
    }

    private void Animations()
    {
        _animator.SetFloat("moveSpeed", Mathf.Abs(_rb.velocity.x));
        _animator.SetBool("isGrounded", _isGrounded);
        _animator.SetBool("canJumpAgain", !_canJumpAgain);
        _animator.SetFloat("isHurt", _knockBackCounter);
    }

    public void KnockBack()
    {
        _knockBackCounter = _knockBackTime;
        _rb.velocity = new Vector2(0f, _knockBackForce);
    }

    public void Bounce()
    {
        _rb.velocity = new Vector2(_rb.velocity.x, _bounceForce);

        AudioManager.instance.PlaySoundClip(11);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Platform")
        {
            transform.parent = collision.transform;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Platform")
        {
            transform.parent = null;
        }
    }
}
