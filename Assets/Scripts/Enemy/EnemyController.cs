using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _enemySprite;

    [SerializeField] private Transform _leftPoint;
    [SerializeField] private Transform _rightPoint;

    [SerializeField] private float _moveSpeed;

    private Rigidbody2D _rb;

    private bool _changeDirection;

    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();

        _leftPoint.parent = null;
        _rightPoint.parent = null;
    }

    // Update is called once per frame
    void Update()
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
