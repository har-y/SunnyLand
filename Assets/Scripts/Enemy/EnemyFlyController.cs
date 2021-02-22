using UnityEngine;

public class EnemyFlyController : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _enemySprite;

    [SerializeField] private Transform _enemy;
    [SerializeField] private Transform[] _points;

    [SerializeField] private float _enemySpeed;

    [SerializeField] private float _attackDistance;
    [SerializeField] private float _attackSpeed;
    [SerializeField] private float _waitAfterAttack;

    private Vector3 _attackTarget;

    private int _currentPoint;

    private float _attackCounter;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        EnemyFlyAttack();
    }

    private void EnemyFlyAttack()
    {
        if (_attackCounter > 0)
        {
            _attackCounter -= Time.deltaTime;
        }
        else
        {
            if (Vector3.Distance(_enemy.position, PlayerController.instance.transform.position) > _attackDistance)
            {
                _attackTarget = Vector3.zero;

                EnemyFlyMove();
            }
            else
            {
                if (_attackTarget == Vector3.zero)
                {
                    _attackTarget = PlayerController.instance.transform.position;
                }

                _enemy.position = Vector3.MoveTowards(_enemy.position, _attackTarget, _attackSpeed * Time.deltaTime);

                if (Vector3.Distance(_enemy.position, _attackTarget) <= 0.1f)
                {
                    _attackCounter = _waitAfterAttack;
                    _attackTarget = Vector3.zero;
                }
            }
        }
    }

    private void EnemyFlyMove()
    {
        _enemy.position = Vector3.MoveTowards(_enemy.position, _points[_currentPoint].position, _enemySpeed * Time.deltaTime);

        if (Vector3.Distance(_enemy.position, _points[_currentPoint].position) <= 0.05f)
        {
            _currentPoint++;

            if (_currentPoint >= _points.Length)
            {
                _currentPoint = 0;
            }
        }

        if (transform.position.x > _points[_currentPoint].position.x)
        {
            _enemySprite.flipX = false;
        }
        else if (transform.position.x < _points[_currentPoint].position.x)
        {
            _enemySprite.flipX = true;
        }
    }
}
