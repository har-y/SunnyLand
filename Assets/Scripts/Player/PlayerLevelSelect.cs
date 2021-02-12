using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLevelSelect : MonoBehaviour
{
    [SerializeField] private MapPoint _currentPoint;

    [SerializeField] private float _moveSpeed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        PlayerCurrentPoint();
    }

    private void PlayerCurrentPoint()
    {
        transform.position = Vector3.MoveTowards(transform.position, _currentPoint.transform.position, _moveSpeed * Time.deltaTime);

        PlayerMove();
    }

    private void PlayerMove()
    {
        if (Vector3.Distance(transform.position, _currentPoint.transform.position) < 0.1f)
        {
            if (Input.GetAxisRaw("Vertical") > 0.5f)
            {
                if (_currentPoint._up != null)
                {
                    SetNextPoint(_currentPoint._up);
                }
            }

            if (Input.GetAxisRaw("Vertical") < -0.5f)
            {
                if (_currentPoint._down != null)
                {
                    SetNextPoint(_currentPoint._down);
                }
            }

            if (Input.GetAxisRaw("Horizontal") > 0.5f)
            {
                if (_currentPoint._right != null)
                {
                    SetNextPoint(_currentPoint._right);
                }
            }

            if (Input.GetAxisRaw("Horizontal") < -0.5f)
            {
                if (_currentPoint._left != null)
                {
                    SetNextPoint(_currentPoint._left);
                }
            }
        }
    }

    private void SetNextPoint(MapPoint nextPoint)
    {
        _currentPoint = nextPoint;
    }
}
