using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Image _bar;
    public float _fill;
    public Animator animator;
    void Start()
    {
        animator = GetComponent<Animator>();
        _fill = 1f;
    }
    void Update()
    {
        _bar.fillAmount = _fill;
        if (Input.GetKeyDown(KeyCode.F))
        {
            _fill -= 0.1f;
            animator.Play("DamageGlitch");
            
        }

    }
}
