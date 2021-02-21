using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelStart : MonoBehaviour
{
    private Countdown _countdown;
    private void Awake()
    {
        _countdown = FindObjectOfType<Countdown>();
    }

    void Start()
    {
        Time.timeScale = 0;
        _countdown.StartCountdown();
    }

    public void levelStart()
    {
        Time.timeScale = 1;
    }
}
