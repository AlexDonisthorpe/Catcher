using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleMovement : MonoBehaviour
{
    [SerializeField] private float speed = 4f;
    private float _step;
    
    private Vector2 _destination;

    private void Awake()
    {
        _step = Time.deltaTime * speed;
    }

    void Start()
    {
        SetDestination();
    }

    private void SetDestination()
    {
        _destination = new Vector2(transform.position.x, Camera.main.ScreenToWorldPoint(Vector2.zero).y);
    }

    private void Update()
    {
        _step = Time.deltaTime * speed;
    }

    void FixedUpdate()
    {
        transform.position = Vector2.MoveTowards(transform.position, _destination, _step);
    }
}
