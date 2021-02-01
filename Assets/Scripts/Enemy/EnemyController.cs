using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _enemySprite;

    [SerializeField] private Transform _leftPoint;
    [SerializeField] private Transform _rightPoint;

    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _moveTime;
    [SerializeField] private float _waitTime;

    private Rigidbody2D _rb;

    private Animator _animator;

    private float _moveCounter;
    private float _waitCounter;

    private bool _changeDirection;

    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();

        _leftPoint.parent = null;
        _rightPoint.parent = null;

        _moveCounter = _moveTime;
    }

    // Update is called once per frame
    void Update()
    {
        EnemyRandomMove();
    }

    private void EnemyRandomMove()
    {
        if (_moveCounter > 0)
        {
            _moveCounter -= Time.deltaTime;

            EnemyMove();

            if (_moveCounter <= 0)
            {
                _waitCounter = Random.Range(_waitTime * 0.75f, _waitTime * 1.25f);
            }

            _animator.SetBool("isMove", true);
        }
        else if (_waitCounter > 0)
        {
            _waitCounter -= Time.deltaTime;

            _rb.velocity = new Vector2(0f, _rb.velocity.y);

            if (_waitCounter <= 0)
            {
                _moveCounter = Random.Range(_moveTime * 0.75f, _moveTime * 0.75f);
            }

            _animator.SetBool("isMove", false);
        }
    }

    private void EnemyMove()
    {
        if (!_changeDirection)
        {
            _rb.velocity = new Vector2(-_moveSpeed, _rb.velocity.y);

            _enemySprite.flipX = false;

            if (transform.position.x < _leftPoint.position.x)
            {
                _changeDirection = true;
            }
        }
        else
        {
            _rb.velocity = new Vector2(_moveSpeed, _rb.velocity.y);

            _enemySprite.flipX = true;

            if (transform.position.x > _rightPoint.position.x)
            {
                _changeDirection = false;
            }
        }
    }
}
