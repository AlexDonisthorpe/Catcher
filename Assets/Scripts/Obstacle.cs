using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    [SerializeField] private int pointsPerObstacle = 200;

    private Animator _animator;
    private void Awake()
    {
        _animator = GetComponentInChildren<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            SelfDestruct();
        } else if (other.CompareTag("Border"))
        {
            FadeAway();
        }
    }

    private void FadeAway()
    {
        _animator.SetTrigger("isFading");
        Destroy(gameObject, _animator.GetCurrentAnimatorStateInfo(0).length);
    }

    private void SelfDestruct()
    {
        GetComponent<ObjectMovement>().Bounce();
        FindObjectOfType<ScoreTracker>().AddToScore(pointsPerObstacle);
        _animator.SetTrigger("expl");
        Destroy(gameObject, _animator.GetCurrentAnimatorStateInfo(0).length);
    }
}