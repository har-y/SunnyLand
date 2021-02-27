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
    [SerializeField] private float _bulletSpeedUp;
    private float _bulletCounter;

    [Header("Boss Tank - Mine")]
    [SerializeField] private GameObject _minePrefab;
    [SerializeField] private Transform _minePoint;
    [SerializeField] private float _mineDelay;
    [SerializeField] private float _mineSpeedUp;
    private float _mineCounter;

    [Header("Boss Tank - Health")]
    [SerializeField] private int _bossHealth;
    [SerializeField] private GameObject _bossExplosion;
    [SerializeField] private bool _isDefeated;

    [Header("Boss Tank - HitBox")]
    [SerializeField] private GameObject _hitBox;
    [SerializeField] private float _hurtTime;
    private float _hurtCounter;

    [Header("Boss Tank - Other")]
    [SerializeField] private GameObject _winPlatform;

    public enum BossState
    {
        move,
        hit,
        shoot,
        end
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
        EnemyBoss();

#if UNITY_EDITOR
        if (Input.GetKeyDown(KeyCode.H))
        {
            TakeHit();
        }
#endif
    }

    private void EnemyBoss()
    {
        switch (_currentState)
        {
            case BossState.move:

                EnemyBossMove();

                break;

            case BossState.hit:

                EnemyBossHit();

                break;

            case BossState.shoot:

                EnemyBossShoot();

                break;

            case BossState.end:

                _winPlatform.SetActive(true);

                AudioManager.instance.PlayMusicClip(4);

                break;

            default:
                break;
        }
    }

    private void EnemyBossMove()
    {
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

        _mineCounter -= Time.deltaTime;

        if (_mineCounter <= 0f)
        {
            _mineCounter = _mineDelay;

            Instantiate(_minePrefab, _minePoint.position, _minePoint.rotation);
        }
    }


    private void EnemyBossHit()
    {
        if (_hurtCounter > 0)
        {
            _hurtCounter -= Time.deltaTime;

            if (_hurtCounter <= 0)
            {
                _mineCounter = 0f;

                _currentState = BossState.move;

                if (_isDefeated)
                {
                    _boss.gameObject.SetActive(false);

                    Instantiate(_bossExplosion, _boss.position, _boss.rotation);

                    _currentState = BossState.end;
                }

            }
        }
    }

    private void EnemyBossShoot()
    {
        _bulletCounter -= Time.deltaTime;

        if (_bulletCounter <= 0)
        {
            _bulletCounter = _bulletDelay;

            GameObject _fire = Instantiate(_bulletPrefab, _bulletPoint.position, _bulletPoint.rotation);
            _fire.transform.localScale = _boss.localScale;
        }
    }

    public void TakeHit()
    {
        _currentState = BossState.hit;

        _hurtCounter = _hurtTime;

        _animator.SetTrigger("isHit");

        AudioManager.instance.PlaySoundClip(1);

        BossTankMine[] mines = FindObjectsOfType<BossTankMine>();

        if (mines.Length > 0f)
        {
            foreach (BossTankMine item in mines)
            {
                item.ExplodeMine();
            }
        }

        _bossHealth--;

        if (_bossHealth <= 0f)
        {
            _isDefeated = true;
        }
        else
        {
            _bulletDelay /= _bulletSpeedUp;
            _mineDelay /= _mineSpeedUp;
        }
    }

    private void StopMovement()
    {
        _currentState = BossState.shoot;

        _bulletCounter = 0f;

        _animator.SetTrigger("isStop");

        _hitBox.SetActive(true);
    }
}
