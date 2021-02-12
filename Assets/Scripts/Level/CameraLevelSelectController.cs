using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraLevelSelectController : MonoBehaviour
{
    [SerializeField] private Transform _target;

    [SerializeField] private Vector2 _minPosition;
    [SerializeField] private Vector2 _maxPosition;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    // Update is called once per frame
    private void LateUpdate()
    {
        float xPos = Mathf.Clamp(_target.position.x, _minPosition.x, _maxPosition.x);
        float yPos = Mathf.Clamp(_target.position.y, _minPosition.y, _maxPosition.y);

        transform.position = new Vector3(xPos, yPos, transform.position.z);
    }
}
