using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    [SerializeField] private bool _dropPlatform;

    [SerializeField] private bool _respawn;
    [SerializeField] private float _respawnTime;

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

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (_dropPlatform)
            {
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
}
