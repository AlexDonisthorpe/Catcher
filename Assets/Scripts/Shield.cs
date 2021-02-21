using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class Shield : MonoBehaviour
{
    [SerializeField] float maxHitsRemaining = 4f;
    [SerializeField] private float energyPerShield = 1f;
    [SerializeField] private Animator _shieldAnimator;
    
    [Header("Testing")]
    [SerializeField] float currentEnergy = 0;
    [SerializeField] float currentHitsRemaining = 0;

    private void Awake()
    {
        currentHitsRemaining = maxHitsRemaining;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Obstacle"))
        {
            currentHitsRemaining--;
            SpeedUpAnimation();
        } else if (other.CompareTag("Energy"))
        {
            UpdateEnergy();
        }
    }

    private void UpdateEnergy()
    {
        currentEnergy++;
        if (currentEnergy % energyPerShield == 0)
        {
            var newHitsRemaining = currentHitsRemaining + 1;
            if (newHitsRemaining > maxHitsRemaining)
            {
                currentHitsRemaining = maxHitsRemaining;
            }
            else
            {
                currentHitsRemaining = newHitsRemaining;
                SlowDownAnimation();
            }
        }
    }

    private void SpeedUpAnimation()
    {
        _shieldAnimator.speed++;
    }
    private void SlowDownAnimation()
    {
        _shieldAnimator.speed--;
    }
}
