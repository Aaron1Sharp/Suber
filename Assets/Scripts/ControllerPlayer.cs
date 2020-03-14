using UnityEngine;
public class ControllerPlayer : MonoBehaviour
{
    public float _speed, _jumpForse, _moveInput, _checkRadius;
    public int _extraJumpValue;
    public bool _isGrounded;
    public Transform _groundCheck;
    public LayerMask _whatIsGround;

    private bool _faceRight = true;
    private int _extraJump;
    private Rigidbody2D _rigidbody2D;
    void Start()
    {
        _extraJump = _extraJumpValue;
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }
    void FixedUpdate()
    {
        _isGrounded = Physics2D.OverlapCircle(
            _groundCheck.position, _checkRadius, _whatIsGround);
        _moveInput = Input.GetAxis("Horizontal");
        _rigidbody2D.velocity = new Vector2(_moveInput * _speed, _rigidbody2D.velocity.y);
        if (_faceRight == false
            && _moveInput > 0
            || _faceRight == true
            && _moveInput < 0)
        { 
            Flip();
        }
    }
    void Update()
    {
        JumpCounter();
        if (_isGrounded == true)
        {
            _extraJump = _extraJumpValue;
        }

        if (Input.GetKeyDown(KeyCode.W)
            && _extraJump > 0)
        {
            _rigidbody2D.velocity = Vector2.up * _jumpForse;
            _extraJump--;
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.W)
                && _extraJump == 0
                && _isGrounded == true)
            {
                _rigidbody2D.velocity = Vector2.up * _jumpForse;
            }
        }
    }
    void Flip()
    {
        _faceRight = !_faceRight;
        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;
    }
    void JumpCounter()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            _extraJumpValue++;
        }
        else if (Input.GetKeyDown(KeyCode.Q) && _extraJumpValue != 0)
             {
                _extraJumpValue--;
             }
    }
}
