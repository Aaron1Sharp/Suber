using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shot : MonoBehaviour
{
    //HealthBar _healthBar;
    public float _speed;
    Transform player;
    Vector2 target;
    void Start()
    {
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
            //_healthBar.FastAnimationHPbarAndTakeHealth();
            DestroyShot();
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")||collision.CompareTag("ground")) 
        {
            //_healthBar.FastAnimationHPbarAndTakeHealth();
            
            DestroyShot();
        }  
    }
    void DestroyShot()
    {
        Destroy(gameObject);
    }
}
