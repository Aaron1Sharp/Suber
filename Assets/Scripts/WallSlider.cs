using UnityEngine;
public class WallSlider : MonoBehaviour
{
    public float _distanceToWall = 0.5f;
    public float _speedSlide = -1f; 
    // если поставить выше 0, то персонаж будет скользить вверх
    ControllerPlayer _player;
    void Start() => _player = GetComponent<ControllerPlayer>();
    void Update()
    {
        Physics2D.queriesStartInColliders = false;
        RaycastHit2D _hit = Physics2D.Raycast(
            transform.position,
            Vector2.right * transform.localScale.x,
            _distanceToWall);

        if (!_player._isGrounded
            && _hit.collider != null
            && GetComponent<Rigidbody2D>().velocity.y < _speedSlide)
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(0, _speedSlide);
        }
        /*если персонаж не на земле но наш луч,
         на дистанции 0.5 пересекается с каким то коллайдером
         И
        возможность немного отпрыгивать от стены*/
    }
}
