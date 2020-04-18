using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
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
        _canvas.SetActive(true);
        animator = GetComponent<Animator>();
        animator.speed = _animatorSpeedPartValue;

    }
    public void Update()
    {

        _HPBar.fillAmount = _fill;
        HPBarDeative();
        if (Input.GetKeyDown(KeyCode.F))
        {
            TakeHealth();
        }
        else if (Input.GetKeyDown(KeyCode.G))
        {
            _fill += _fillPathValue;
            animator.speed -= _animatorSpeedPartValue;
        }

    }

    private void HPBarDeative()
    {

        if (_fill <= 0)
        {
            SceneManager.LoadScene("Main_menu");
        }

    }

    public void TakeHealth()
    {

        _fill -= _fillPathValue;
        animator.speed += _animatorSpeedPartValue;

    }
}
