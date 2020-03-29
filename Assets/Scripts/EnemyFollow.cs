using UnityEngine;
public class EnemyFollow : MonoBehaviour
{
    public float _speedFollowEnemy, _stoppingDistance, healthEnemyFollow, _startTimeBetween;
    public GameObject EnemyBloodPS;
    public GameObject _projectTile;
    public HealthBar _healthBar;
    public Animator ShakeCamera;
    float _timeBetweenShots;
    Transform FollowTarget;
    public void Start()
    {
        FollowTarget = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        healthEnemyFollow = 1f;
        _timeBetweenShots = _startTimeBetween;
    }

    public void Update()
    {
        if (_timeBetweenShots <= 0)
        {
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
        if (collision.gameObject.name == "Player")
        {
            Instantiate(EnemyBloodPS, transform.position, Quaternion.identity);
            ShakeCameraMethod();
        }

        if (Input.GetKey(KeyCode.R) && collision.gameObject.name == "Player") 
        {
            TakeDamage();
            Debug.Log("enemyfallow");
        }

        else if (!Input.GetKey(KeyCode.R) && collision.gameObject.name == "Player")
        {
            _healthBar.FastAnimationHPbarAndTakeHealth();
            Debug.Log("meleeDamage");
        }
    }
    public void TakeDamage()
    {
        healthEnemyFollow -= 0.3f;
        if (healthEnemyFollow <= 0)
        {
            Destroy(gameObject);
        }
    }
    public void ShakeCameraMethod()
    {
        ShakeCamera.SetTrigger("Shake");
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
