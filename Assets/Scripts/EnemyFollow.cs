using UnityEngine;
public class EnemyFollow : MonoBehaviour
{
    public float _speedFollowEnemy;
    public float _stoppingDistance;
    public GameObject EnemyBloodPS;
    public GameObject _enemyFollow;
    private Transform FollowTarget;
    void Start()
    {
        FollowTarget = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        _enemyFollow = GetComponent<GameObject>();
    }

    void Update()
    {
        if (Vector2.Distance(transform.position, FollowTarget.position) > _stoppingDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, FollowTarget.position,
                                                     _speedFollowEnemy * Time.deltaTime);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        Instantiate(EnemyBloodPS, transform.position, Quaternion.identity);
    }
}
