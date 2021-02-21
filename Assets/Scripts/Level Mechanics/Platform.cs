using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    [SerializeField] private bool _dropPlatform;
    [SerializeField] private bool _respawn;
    [SerializeField] private float _respawnTime;

    [SerializeField] private bool _movingPlatform;
    [SerializeField] private Transform _platform;
    [SerializeField] private Transform[] _points;
    [SerializeField] private int _currentPoint;
    [SerializeField] private float _platformSpeed;

    private Rigidbody2D _rb;

    private Vector2 _startPosition;

    private bool _changeDirection;

    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _startPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        MovingPlatform();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (_dropPlatform)
            {
                Debug.Log("drop platform");

                DropPlatform();
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Dead Zone" && _respawn)
        {
            StartCoroutine(RespawnPlatformCoroutine());
        }
    }

    private IEnumerator RespawnPlatformCoroutine()
    {
        yield return new WaitForSeconds(_respawnTime);

        RespawnPlatform();
    }


    private void DropPlatform()
    {
        _rb.isKinematic = false;
    }

    private void RespawnPlatform()
    {
        _rb.isKinematic = true;
        _rb.velocity = new Vector3(0f, 0f, 0f);
        transform.position = _startPosition;
    }

    private void MovingPlatform()
    {
        if (_movingPlatform)
        {
            _platform.position = Vector3.MoveTowards(_platform.position, _points[_currentPoint].position, _platformSpeed * Time.deltaTime);

            if (Vector3.Distance(_platform.position, _points[_currentPoint].position) <= 0.05f)
            {
                _currentPoint++;

                if (_currentPoint >= _points.Length)
                {
                    _currentPoint = 0;
                }
            }
        }
    }
}
