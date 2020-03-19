using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shot : MonoBehaviour
{
    public float _speed;
    //HealthBar _healthBar;
    Transform player;
    Vector2 target;
    void Start()
    {
        //_healthBar = GetComponent<HealthBar>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        target = new Vector2(player.position.x, player.position.y);
    }
    void Update()
    {
        // Если мне надо что бы выстрел следил за игроком а не летел в место точки позиции игрока 
        // то надо изменить target на player.posititon
        transform.position = Vector2.MoveTowards(transform.position, target, _speed * Time.deltaTime);
        if (transform.position.x == target.x && transform.position.y == target.y) 
        {
            Debug.Log("Enter");
            //_healthBar.FastAnimationHPbarAndTakeHealth();
            DestroyShot();
        }
    }
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!(collision.gameObject.name == "EnemyFollow"))
        {
            DestroyShot();
        }
        else if (collision.gameObject.name == "Player")
        {
            Debug.Log("EnterTrigger");
        }
    }
    void DestroyShot()
    {
        Destroy(gameObject);
    }
}
