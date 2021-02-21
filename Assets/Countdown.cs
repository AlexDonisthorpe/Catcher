using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Countdown : MonoBehaviour
{
    private int currentTimeRemaining = 3;
    
    private Text _countdownText;
    private Animator _animator;
    private void Awake()
    {
        _countdownText = GetComponent<Text>();
        _animator = GetComponent<Animator>();
    }

    public void DeductTimer()
    {
        currentTimeRemaining--;

        UpdateText();

        if (currentTimeRemaining == 0)
        {
            FindObjectOfType<LevelStart>().levelStart();
        }
    }

    private void UpdateText()
    {
        if (currentTimeRemaining == 0)
        {
            _countdownText.text = "Go!";
            _countdownText.fontSize = 50;
        }
        else
        {
            _countdownText.text = currentTimeRemaining.ToString();
        }
    }

    public void StartCountdown()
    {
        _animator.SetBool("isStarting", true);
    }
    
    public void ClearCountdown()
    {
        _animator.SetBool("isStarting", false);
        gameObject.SetActive(false);
    }
}
