using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private Transform _farBackground;
    [SerializeField] private Transform _middleBackground;

    private float _xLastPosition;

    // Start is called before the first frame update
    void Start()
    {
        _xLastPosition = transform.position.x;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(_target.position.x, transform.position.y, transform.position.z);

        float xOffset = transform.position.x - _xLastPosition;

        _farBackground.position += new Vector3(xOffset, 0f, 0f);
        _middleBackground.position += new Vector3(xOffset * 0.5f, 0f, 0f);

        _xLastPosition = transform.position.x;
    }
}
