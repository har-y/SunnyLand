using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLevelSelect : MonoBehaviour
{
    [SerializeField] private MapPoint _currentPoint;

    [SerializeField] private float _moveSpeed;

    private bool _levelLoading;

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
        if (Vector3.Distance(transform.position, _currentPoint.transform.position) < 0.1f && !_levelLoading)
        {
            if (Input.GetAxisRaw("Vertical") > 0.5f)
            {
                if (_currentPoint._up != null)
                {
                    SetNextPoint(_currentPoint._up);
                }
            }
            else if (Input.GetAxisRaw("Vertical") < -0.5f)
            {
                if (_currentPoint._down != null)
                {
                    SetNextPoint(_currentPoint._down);
                }
            }
            else if(Input.GetAxisRaw("Horizontal") > 0.5f)
            {
                if (_currentPoint._right != null)
                {
                    SetNextPoint(_currentPoint._right);
                }
            }
            else if (Input.GetAxisRaw("Horizontal") < -0.5f)
            {
                if (_currentPoint._left != null)
                {
                    SetNextPoint(_currentPoint._left);
                }
            }

            if (_currentPoint._isLevel)
            {
                if (Input.GetButtonDown("Jump"))
                {
                    _levelLoading = true;
                }
            }
        }
    }

    private void SetNextPoint(MapPoint nextPoint)
    {
        _currentPoint = nextPoint;
    }
}
