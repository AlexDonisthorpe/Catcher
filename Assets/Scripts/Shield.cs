using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour
{
    [SerializeField] float hitsUntilDeath = 4f;
    [SerializeField] private float energyPerShield = 1f;
    
    [Header("Testing")]
    [SerializeField] float currentEnergy = 0;
    [SerializeField] float currentHitsRemaining = 0;

    private void Awake()
    {
        currentHitsRemaining = hitsUntilDeath;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Obstacle"))
        {
            currentHitsRemaining--;
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
            currentHitsRemaining = Mathf.Clamp((currentHitsRemaining+1),0, hitsUntilDeath);
        }
    }
}
