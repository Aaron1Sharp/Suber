using UnityEngine;
using UnityEngine.UI;
public class HealthBar : MonoBehaviour
{
    const float _fillPathValue = 0.1f;
    const float _animatorSpeedPartValue = 0.05f;
    public float _fill;
    Animator animator;
    public Image _HPBar;
    public GameObject _canvas;
    public void Start()
    {
        _fill = 1f;
        animator = GetComponent<Animator>();
        animator.speed = _animatorSpeedPartValue;
    }
    public void Update()
    {
        _HPBar.fillAmount = _fill;
        if (Input.GetKeyDown(KeyCode.F))
        {
            FastAnimationHPbarAndTakeHealth();
            if (_fill <= 0)
            {
                _canvas.SetActive(false);
            }
        }
        else if (Input.GetKeyDown(KeyCode.G))
        {
            _fill += _fillPathValue;
            animator.speed -= _animatorSpeedPartValue;
        }
    }

    public void FastAnimationHPbarAndTakeHealth()
    {
        _fill -= _fillPathValue;
        animator.speed += _animatorSpeedPartValue;
    }
}
