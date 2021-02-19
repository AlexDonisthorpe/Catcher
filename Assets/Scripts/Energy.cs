using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Energy : MonoBehaviour
{
    private Animator _animator;
    void Awake()
    {
        _animator = GetComponentInChildren<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Border"))
        {
            _animator.SetTrigger(("isFading"));
            Destroy(gameObject, _animator.GetCurrentAnimatorStateInfo(0).length);
        }

        if (other.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }
}
