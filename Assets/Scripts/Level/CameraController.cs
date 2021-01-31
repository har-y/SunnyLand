using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private Transform _farBackground;
    [SerializeField] private Transform _middleBackground;

    [SerializeField] private float _minHeight;
    [SerializeField] private float _maxHeight;

    private Vector2 _lastPosition;
    private Vector2 _backgroundOffset;

    private float _backgroundSpeed = 0.5f;

    // Start is called before the first frame update
    void Start()
    {
        _lastPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        CameraFollow();

        ParallaxBackground();
    }

    private void CameraFollow()
    {
        transform.position = new Vector3(_target.position.x, Mathf.Clamp(_target.position.y, _minHeight, _maxHeight), transform.position.z);
    }

    private void ParallaxBackground()
    {
        _backgroundOffset = new Vector2(transform.position.x - _lastPosition.x, transform.position.y - _lastPosition.y);
        _lastPosition = transform.position;

        _farBackground.position += new Vector3(_backgroundOffset.x, _backgroundOffset.y, 0f);
        _middleBackground.position += new Vector3(_backgroundOffset.x, _backgroundOffset.y, 0f) * _backgroundSpeed;
    }
}
