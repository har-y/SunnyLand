using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bouncer : MonoBehaviour
{
    [SerializeField] private float _bounceForce;

    private Animator _animator;

    private bool _canBounce;

    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponent<Animator>();
        _canBounce = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<Rigidbody2D>().velocity = (Vector2.up * _bounceForce);
            _animator.Play("bouncer_up");

            _canBounce = false;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        _canBounce = true;
    }
}
