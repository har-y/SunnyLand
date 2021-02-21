using UnityEngine;

public class EnemyFlyController : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _enemySprite;

    [SerializeField] private Transform _enemy;
    [SerializeField] private Transform[] _points;

    [SerializeField] private float _enemySpeed;

    private int _currentPoint;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        FlyingEnemy();
    }


    private void FlyingEnemy()
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
