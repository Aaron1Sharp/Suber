using UnityEngine;

public class Shot : MonoBehaviour
{

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
            Debug.Log("Достиг места");
            DestroyShot();
        }

    }
    
    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (!(collision.gameObject.name == "EnemyFollow"))
        {
            DestroyShot();
        }

    }

    void DestroyShot()
    {

        Destroy(gameObject);

    }
}
