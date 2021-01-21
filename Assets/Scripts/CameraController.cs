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

    private float _xLastPosition;

    // Start is called before the first frame update
    void Start()
    {
        _xLastPosition = transform.position.x;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(_target.position.x, Mathf.Clamp(transform.position.y, _minHeight, _maxHeight), transform.position.z);

        float backgroundOffset = transform.position.x - _xLastPosition;
        float backgroundSpeed = 0.5f;

        _farBackground.position += new Vector3(backgroundOffset, 0f, 0f);
        _middleBackground.position += new Vector3(backgroundOffset * backgroundSpeed, 0f, 0f);

        _xLastPosition = transform.position.x;
    }
}
