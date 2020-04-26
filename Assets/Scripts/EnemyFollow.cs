using UnityEngine;
public class EnemyFollow : MonoBehaviour
{
    public float _speedFollowEnemy, _stoppingDistance, _startTimeBetween, damage;
    public GameObject EnemyBloodPS;
    public GameObject _projectTile;

    private float _timeBetweenShots;
    private Transform FollowTarget;
    private Animator _animator;

    public void Start()
    {
        _animator = GetComponent<Animator>();
        FollowTarget = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        _animator.SetBool("IsIdle", true);
        _timeBetweenShots = _startTimeBetween;
    }

    public void Update()
    {
        if (_timeBetweenShots <= 0)
        {
            _animator.SetTrigger("Attack");
            Instantiate(_projectTile,transform.position,Quaternion.identity);
            _timeBetweenShots = _startTimeBetween;
        }

        else
        {
            _timeBetweenShots -= Time.deltaTime;
        }

        if (Vector2.Distance(transform.position, FollowTarget.position) > _stoppingDistance)
        { 
            transform.position = Vector2.MoveTowards(transform.position, FollowTarget.position,
                                                     _speedFollowEnemy * Time.deltaTime);
        }
    }
}
/*
        * 
        * Отталкивает противника при приближеннии игрока
        * 
        *else if (Vector2.Distance(transform.position, FollowTarget.position) < _stoppingDistance
             &&  Vector2.Distance(transform.position, FollowTarget.position) > _retreatsDistance)
             {
                transform.position = transform.position;
             }
        else if (Vector2.Distance(transform.position, FollowTarget.position) < _retreatsDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, FollowTarget.position,
                                                     -_speedFollowEnemy * Time.deltaTime);
        }
        */
