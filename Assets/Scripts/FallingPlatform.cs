using UnityEngine;
public class FallingPlatform : MonoBehaviour
{

    Rigidbody2D _rigidbody2D;
    Vector2 _currentPosition;
    bool _isMoveBack;

    void Start()
    {

        _rigidbody2D = GetComponent<Rigidbody2D>();
        _currentPosition = transform.position;

    }
    private void Update()
    {

        if (_isMoveBack == true)
        {
            transform.position = Vector2.MoveTowards(transform.position, _currentPosition, 20f * Time.deltaTime);
        }

        if ((transform.position.y == _currentPosition.y) && (transform.position.x == _currentPosition.x))
        {
            _isMoveBack = false;
        }

    }
    void OnCollisionEnter2D(Collision2D collision)
    {

        if ((collision.gameObject.name.Equals("Player")|| collision.gameObject.CompareTag("ground")) && _isMoveBack == false) 
        {
            Invoke("FallPlatform", 2f);
        }

        if (collision.gameObject.CompareTag("Player"))
        {
            collision.transform.parent = transform;
        }

    }
    private void OnCollisionExit2D(Collision2D collision)
    {

        if (collision.gameObject.CompareTag("Player"))
        {
            collision.transform.parent = null;
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
            _isMoveBack = true;

        }
}
