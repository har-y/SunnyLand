using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossTankController : MonoBehaviour
{
    [Header("Boss Tank")]
    private Animator _animator;
    [SerializeField] private Transform _boss;
    [SerializeField] private BossState _currentState;

    [Header("Boss Tank - Movement")]
    [SerializeField] private Transform _leftPoint;
    [SerializeField] private Transform _rightPoint;
    [SerializeField] private float _moveSpeed;
    private bool _changeDirection;

    [Header("Boss Tank - Bullet")]
    [SerializeField] private GameObject _bulletPrefab;
    [SerializeField] private Transform _bulletPoint;
    [SerializeField] private float _bulletDelay;
    private float _bulletCounter;

    [Header("Boss Tank - Health")]
    [SerializeField] private float _hurtTime;
    private float _hurtCounter;

    public enum BossState
    {
        move,
        hit,
        shoot
    }

    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponent<Animator>();

        _currentState = BossState.shoot;
    }

    // Update is called once per frame
    void Update()
    {
        switch (_currentState)
        {
            case BossState.move:

                if (_changeDirection)
                {
                    _boss.position += new Vector3(_moveSpeed * Time.deltaTime, 0f, 0f);

                    if (_boss.position.x >= _rightPoint.position.x)
                    {
                        _boss.localScale = new Vector3(1f, 1f, 1f);

                        _changeDirection = false;

                        StopMovement();
                    }
                }
                else
                {
                    _boss.position -= new Vector3(_moveSpeed * Time.deltaTime, 0f, 0f);

                    if (_boss.position.x <= _leftPoint.position.x)
                    {
                        _boss.localScale = new Vector3(-1f, 1f, 1f);

                        _changeDirection = true;

                        StopMovement();
                    }
                }

                break;

            case BossState.hit:

                if (_hurtCounter > 0)
                {
                    _hurtCounter -= Time.deltaTime;

                    if (_hurtCounter <= 0)
                    {
                        _currentState = BossState.move;
                    }
                }

                break;

            case BossState.shoot:
                break;

            default:
                break;
        }

#if UNITY_EDITOR
        if (Input.GetKeyDown(KeyCode.H))
        {
            TakeHit();
        }
#endif
    }

    public void TakeHit()
    {
        _currentState = BossState.hit;

        _hurtCounter = _hurtTime;

        _animator.SetTrigger("isHit");
    }

    private void StopMovement()
    {
        _currentState = BossState.shoot;

        _bulletCounter = _bulletDelay;

        _animator.SetTrigger("isStop");
    }
}
