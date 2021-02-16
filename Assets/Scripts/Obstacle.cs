using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    [SerializeField] private float pointsPerObstacle = 200f;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            SelfDestruct();
        }
    }

    private void SelfDestruct()
    {
        GetComponent<ObjectMovement>().Bounce();
        Animator _animator = GetComponentInChildren<Animator>();
        _animator.SetTrigger("expl");
        Destroy(gameObject, _animator.GetCurrentAnimatorStateInfo(0).length);
    }
}