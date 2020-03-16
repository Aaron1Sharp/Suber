
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float _dumping = 1.5f;
    public Vector2 _offset = new Vector2(2f, 1f);
    public bool _isLeft;
    private Transform _player;
    private int _lastX;
    void Start()
    {
        _offset = new Vector2(Mathf.Abs(_offset.x), _offset.y);
        FindPlayer(_isLeft);
    }
    public void FindPlayer(bool _playerIsLeft)
    {
        _player = GameObject.FindGameObjectWithTag("Player").transform;
        _lastX = Mathf.RoundToInt(_player.position.x);

        transform.position = _playerIsLeft
            ? new Vector3( _player.position.x - _offset.x,
                _player.position.y + _offset.y, transform.position.z)           
            //вектор z нужно обьявлять именно transform что бы камера не фокусилась на z = 0
            : new Vector3( _player.position.x + _offset.x,
                _player.position.y + _offset.y, transform.position.z);
    }
    void Update()
    {
        if (_player)
        {
            if (Mathf.RoundToInt(_player.position.x) > _lastX)
            {
                _isLeft = false;
            }
            else if (Mathf.RoundToInt(_player.position.x) < _lastX)
            {
                _isLeft = true;
            }
            _lastX = Mathf.RoundToInt(_player.position.x);

            Vector3 _target = _isLeft
                ? new Vector3( _player.position.x - _offset.x,
                    _player.position.y + _offset.y, transform.position.z)
                : new Vector3( _player.position.x + _offset.x,
                    _player.position.y + _offset.y, transform.position.z);

            Vector3 _currentPosition = Vector3.Lerp(
                transform.position,
                _target,
                _dumping * Time.deltaTime);
            transform.position = _currentPosition;
        }
    }
}
