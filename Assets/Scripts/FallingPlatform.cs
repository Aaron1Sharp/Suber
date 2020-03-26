using UnityEngine;
public class FallingPlatform : MonoBehaviour
{
    Rigidbody2D _rigidbody2D;
    Vector2 _currentPosition;
    bool _moveingBack;
    void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _currentPosition = transform.position;
    }
    private void Update()
    {
        if (_moveingBack == true)
        {
            transform.position = Vector2.MoveTowards(transform.position, _currentPosition, 20f * Time.deltaTime);
        }

        if (transform.position.y == _currentPosition.y)
        {
            _moveingBack = false;
        }
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if ((collision.gameObject.name.Equals("Player") || collision.gameObject.CompareTag("ground")) && _moveingBack == false) 
        {
            Invoke("FallPlatform", 2f);
        }   
    }
        void FallPlatform()
        {
            _rigidbody2D.isKinematic = false;
            Invoke("BackPlatform", 2f);
        }

        void BackPlatform()
        {
            _rigidbody2D.velocity = Vector2.zero;
            _rigidbody2D.isKinematic = true;
            _moveingBack = true;
        }
}
