using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Smasher : MonoBehaviour
{
    [SerializeField] private Transform _smasher;
    [SerializeField] private Transform _smasherPoint;

    [SerializeField] private float _smashWait;
    [SerializeField] private float _smashSpeed;
    [SerializeField] private float _resetSpeed;

    private float _waitCounter;

    private Vector3 _startPosition;

    private bool _smash;
    private bool _resetSmash;

    // Start is called before the first frame update
    void Start()
    {
        _startPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (!_smash && !_resetSmash)
        {
            if (Vector3.Distance(_smasherPoint.position, PlayerController.instance.transform.position) < 2f)
            {
                _smash = true;
                _waitCounter = _smashWait;
            }
        }

        if (_smash)
        {
            _smasher.position = Vector3.MoveTowards(_smasher.position, _smasherPoint.position, _smashSpeed * Time.deltaTime);

            if (_smasher.position == _smasherPoint.position)
            {
                _waitCounter -= Time.deltaTime;

                if (_waitCounter <= 0)
                {
                    _smash = false;
                    _resetSmash = true;
                }


            }
        }

        if (_resetSmash)
        {
            _smasher.position = Vector3.MoveTowards(_smasher.position, _startPosition, _resetSpeed * Time.deltaTime);

            if (_smasher.position == _startPosition)
            {
                _resetSmash = false;
            }
        }
    }
}
