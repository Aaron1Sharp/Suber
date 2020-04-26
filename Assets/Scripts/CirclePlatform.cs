using UnityEngine;
public class CirclePlatform : MonoBehaviour
{
#pragma warning disable 0649
    [SerializeField]
    private Transform _center;
    [SerializeField]
    float _radius = 2f, _angularSpeed = 2f;
    float _positionX, _positionY, _angle = 0f;

    void FixedUpdate()
    {
        
        _positionX = _center.position.x + (Mathf.Cos(_angle) * _radius);
        _positionY = _center.position.y + (Mathf.Sin(_angle) * _radius);
        transform.position = new Vector2(_positionX, _positionY);
        _angle += Time.deltaTime * _angularSpeed;

        if (_angle >= 360f)
            _angle = 0f;
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.CompareTag("Player"))
            collision.transform.parent = transform;    

    }
    private void OnCollisionExit2D(Collision2D collision)
    {

        if (collision.gameObject.CompareTag("Player"))
            collision.transform.parent = null;

    }
}

