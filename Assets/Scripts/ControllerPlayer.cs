using UnityEngine;
using UnityEngine.SceneManagement;
public class ControllerPlayer : MonoBehaviour
{
    [Range(0, 10)] public int _extraJumpValue;
    public float _speed, _jumpForse, _moveInput, _checkRadius,_damage;
    public bool _isGrounded;
    public Transform _groundCheck;
    public LayerMask _whatIsGround;
    public GameObject _dustFromTheGround;
    public HealthBar _healthBar;

    private bool _faceRight = true;
    private int _extraJump;
    private Animator _animator;
    private Rigidbody2D _rigidbody2D;

    void Start()
    {
        _animator = GetComponent<Animator>();
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _extraJump = _extraJumpValue;
    }

    void FixedUpdate()
    {
        _isGrounded = Physics2D.OverlapCircle(_groundCheck.position, _checkRadius, _whatIsGround);
        _moveInput = Input.GetAxis("Horizontal");
        _rigidbody2D.velocity = new Vector2(_moveInput * _speed, _rigidbody2D.velocity.y);
        if (_faceRight == false && _moveInput > 0 || _faceRight == true && _moveInput < 0)
        {
            Flip();
        }
    }

    void Update()
    {      
        JumpCounter();
        if (_isGrounded == true)
        {
            if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
            {
                _animator.SetBool("isWalk", true);
            }

            else
            {
                _animator.SetBool("isWalk", false);
            }
            _extraJump = _extraJumpValue;
        }

        else
        {
            _animator.SetBool("isWalk", false);
        }

        if (Input.GetKeyDown(KeyCode.W) && _extraJump > 0)
        {
            Instantiate(_dustFromTheGround, transform.position, Quaternion.identity);
            _rigidbody2D.velocity = Vector2.up * _jumpForse;
            _animator.SetTrigger("jump");
            _extraJump--;
        }

        else
        {
            if (Input.GetKeyDown(KeyCode.W) && _extraJump == 0 && _isGrounded == true)
            {
                _animator.SetTrigger("jump");
                _rigidbody2D.velocity = Vector2.up * _jumpForse;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (Input.GetKey(KeyCode.R) && collision.CompareTag("EnemyFly"))
        {
            Destroy(collision.gameObject);           
        }

        else if (!Input.GetKey(KeyCode.R) && collision.CompareTag("EnemyFly"))
        {
            _healthBar.TakeHealth();
        }
    }

    private void Flip()
    {
        _faceRight = !_faceRight;
        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;
    }

    private void JumpCounter()
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
