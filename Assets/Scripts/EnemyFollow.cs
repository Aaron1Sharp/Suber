using UnityEngine;
public class EnemyFollow : MonoBehaviour
{

    public float _speedFollowEnemy, _stoppingDistance, healthEnemyFollow, _startTimeBetween;
    public GameObject EnemyBloodPS;
    public GameObject _projectTile;
    public HealthBar _healthBar;
    public Animator _ShakeCamera;
    float _timeBetweenShots;
    Transform FollowTarget;
    Animator _animator;

    public void Start()
    {
        
        _animator = GetComponent<Animator>();
        FollowTarget = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        healthEnemyFollow = 1f;
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
    private void OnTriggerExit2D(Collider2D collision)
    {

        if (Input.GetKey(KeyCode.R) && collision.gameObject.name == "Player") 
        {
            ShakeAndBloodMade();
            TakeDamage();
        }

        else if (!Input.GetKey(KeyCode.R) && collision.gameObject.name == "Player")
        {
            ShakeAndBloodMade();
            _healthBar.TakeHealth();
        }

    }

    private void ShakeAndBloodMade()
    {

        Instantiate(EnemyBloodPS, transform.position, Quaternion.identity);
        _ShakeCamera.SetTrigger("Shake");

    }

    public void TakeDamage()
    {

        healthEnemyFollow -= 0.3f;
        if (healthEnemyFollow <= 0)
        {
            Destroy(gameObject);
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
